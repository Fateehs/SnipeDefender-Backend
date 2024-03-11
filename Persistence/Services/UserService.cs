using Application.Abstractions.Services;
using Domain.Entities;
using Persistence.Contexts;

public class UserService : IUserService
{
    private readonly SnipeDefenderDBContext _dbContext;

    public UserService(SnipeDefenderDBContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task CreateUser(User user)
    {
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateUser(User user)
    {
        var existingUser = await _dbContext.Users.FindAsync(user.Id);

        if (existingUser == null)
        {
            throw new Exception("User not found");
        }

        existingUser.SteamID = user.SteamID;
        existingUser.UserName = user.UserName;
        existingUser.Password = user.Password;
        existingUser.Twitch = user.Twitch;
        existingUser.Hours = user.Hours;
        existingUser.Discord = user.Discord;
        existingUser.SteamPicture = user.SteamPicture;
        existingUser.Reputation = user.Reputation;

        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteUser(User user)
    {
        var existingUser = await _dbContext.Users.FindAsync(user.Id);

        if (existingUser == null)
        {
            throw new Exception("User not found");
        }

        _dbContext.Users.Remove(existingUser);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<User> GetUserById(int userId)
    {
        var user = await _dbContext.Users.FindAsync(userId);

        if (user == null)
        {
            throw new Exception("User not found");
        }

        return user;
    }
}
