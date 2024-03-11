using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Services
{
    public interface IUserService
    {
        Task CreateUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(User user);
        Task<User> GetUserById(int userId);
    }
}
