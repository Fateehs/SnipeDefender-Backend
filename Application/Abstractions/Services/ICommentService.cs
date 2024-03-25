using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Services
{
    public interface ICommentService
    {
        Task AddCommentAsync(int userId, int playerId, string text, int reputation);
        Task RemoveCommentAsync(int commentId);
        Task<List<Comment>> GetAllCommentsAsync();
        Task<List<Comment>> GetCommentsByPlayerIdAsync(int playerId);
    }
}
