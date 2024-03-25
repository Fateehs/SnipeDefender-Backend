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
    public class PlayerService : IPlayerService
    {
        private readonly SnipeDefenderDBContext _dbContext;

        public PlayerService(SnipeDefenderDBContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task CreatePlayer(Player player)
        {
            _dbContext.Players.Add(player);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateUser(Player player)
        {
            var existingPlayer = await _dbContext.Players.FindAsync(player.Id);

            if (existingPlayer == null)
            {
                throw new Exception("Player not found");
            }

            existingPlayer.SteamID = player.SteamID;
            existingPlayer.UserName = player.UserName;
            existingPlayer.Twitch = player.Twitch;
            existingPlayer.Hours = player.Hours;
            existingPlayer.Discord = player.Discord;
            existingPlayer.SteamPicture = player.SteamPicture;
            existingPlayer.Reputation = player.Reputation;

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteUser(Player player)
        {
            var existingPlayer = await _dbContext.Players.FindAsync(player.Id);

            if (existingPlayer == null)
            {
                throw new Exception("Player not found");
            }

            _dbContext.Players.Remove(existingPlayer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Player> GetPlayerById(int playerId)
        {
            var player = await _dbContext.Players.FindAsync(playerId);

            if (player == null)
            {
                throw new Exception("Player not found");
            }

            return player;
        }

        public async Task<List<Player>> GetPlayers()
        {
            return await _dbContext.Players.ToListAsync();
        }
    }
}
