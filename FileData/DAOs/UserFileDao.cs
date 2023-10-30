using Application.DaoInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace FileData.DAOs;

public class UserFileDao : IUserDao
{
    private readonly FileContext context;

    public UserFileDao(FileContext context)
    {
        this.context = context;
    }
    
    //dodać usera
    public Task<User> CreateAsync(User user)
    {
        int userId = 1;
        if (context.Users.Any())
        {
            userId = context.Users.Max(u => u.Id);
            userId++;
        }

        user.Id = userId;

        context.Users.Add(user);
        context.SaveChanges();

        return Task.FromResult(user);
    }
    
    public Task<User?> GetByUsernameAsync(string userName)
    {
        User? existing = context.Users.FirstOrDefault(u =>
            u.userName.Equals(userName, StringComparison.OrdinalIgnoreCase)
        );
        return Task.FromResult(existing);
    }
    
    public Task<IEnumerable<User>> GetAsync(SearchUserParametersDto searchParameters)
    {
        IEnumerable<User> users = context.Users.AsEnumerable();
        if (searchParameters.UsernameContains != null)
        {
            users = context.Users.Where(u => u.userName.Contains(searchParameters.UsernameContains, StringComparison.OrdinalIgnoreCase));
        }

        return Task.FromResult(users);
    }

    public Task<User?> GetByIdAsync(int dtoUserId)
    {
        User? existing = context.Users.FirstOrDefault(u => u.Id == dtoUserId);
        return Task.FromResult(existing);
    }
}