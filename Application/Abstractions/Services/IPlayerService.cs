using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Services
{
    public interface IPlayerService
    {
        Task CreatePlayer(Player player);
        Task UpdateUser(Player player);
        Task DeleteUser(Player player);
        Task<Player> GetPlayerById(int playerId);
        Task<List<Player>> GetPlayers();
    }
}
