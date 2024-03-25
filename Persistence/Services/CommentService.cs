using Application.Abstractions.Services;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Services
{
    public class CommentService : ICommentService
    {
        private readonly IUserService _userService;
        private readonly IPlayerService _playerService;
        private readonly SnipeDefenderDBContext _dbContext;

        public CommentService(IPlayerService playerService, IUserService userService, SnipeDefenderDBContext snipeDefenderDBContext)
        {
            _playerService = playerService;
            _userService = userService;
            _dbContext = snipeDefenderDBContext;
        }

        public async Task AddCommentAsync(int userId, int playerId, string text, int reputation)
        {
            var user = await _userService.GetUserById(userId);
            if (user == null)
            {
                throw new ArgumentException("User not found");
            }

            var player = await _playerService.GetPlayerById(playerId);
            if (player == null)
            {
                throw new ArgumentException("Player not found");
            }

            var comment = new Comment
            {
                UserId = userId,
                PlayerId = playerId,
                Text = text,
                Reputation = reputation,
                UserName = user.UserName,
                UserSteamPicture = user.SteamPicture,
                CreatedAt = DateTime.UtcNow
            };

            _dbContext.Comments.Add(comment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveCommentAsync(int commentId)
        {
            var comment = await _dbContext.Comments.FindAsync(commentId);
            if (comment == null)
            {
                throw new ArgumentException("Comment not found");
            }

            _dbContext.Comments.Remove(comment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Comment>> GetAllCommentsAsync()
        {
            return await _dbContext.Comments.ToListAsync();
        }

        public async Task<List<Comment>> GetCommentsByPlayerIdAsync(int playerId)
        {
            return await _dbContext.Comments.Where(c => c.PlayerId == playerId).ToListAsync();
        }
    }
}
