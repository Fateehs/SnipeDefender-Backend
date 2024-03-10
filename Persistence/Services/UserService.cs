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
}
