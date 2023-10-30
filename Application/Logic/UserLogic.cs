using Application.DaoInterfaces;
using Application.LoginInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace Application.Logic;

public class UserLogic : IUserLogic
{
    private readonly IUserDao userDao;

    public UserLogic(IUserDao userDao)
    {
        this.userDao = userDao;
    }
    
    public async Task<User> CreateAsync(UserCreationDto dto)
    {
        User? existing = await userDao.GetByUsernameAsync(dto.UserName);
        if (existing != null)
            throw new Exception("Username already taken!");

        ValidateData(dto);
        User toCreate = new User
        {
            userName = dto.UserName,
            password = dto.Password
        };
        
        User created = await userDao.CreateAsync(toCreate);
        
        return created;
    }

    public Task<IEnumerable<User>> GetAsync(SearchUserParametersDto searchParameters)
    {
        return userDao.GetAsync(searchParameters);
    }

    //static cos it's a 'utility method' just takes an argument does sth with it returns void or some object
    private static void ValidateData(UserCreationDto userToCreate)
    {
        string userName = userToCreate.UserName;
        string password = userToCreate.Password;

        if (userName.Length < 3)
            throw new Exception("Username must be at least 3 characters!");
        if (userName.Length > 15)
            throw new Exception("Username must be less than 16 characters!");
        if (password.Length < 3)    
            throw new Exception("Password must be at least 3 characters!");
        if (password.Length >15)
            throw new Exception("Password must be shorter than 15 characters");
    }
    
    
}