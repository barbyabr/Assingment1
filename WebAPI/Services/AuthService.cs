using System.ComponentModel.DataAnnotations;
using Application.DaoInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace WebAPI.Services;

public class AuthService : IAuthService
{
    private readonly IUserDao userDao;

    public AuthService(IUserDao userDao)
    {
        this.userDao = userDao;
    }
    
    
    
    public async Task<User> GetUser(string username, string password)
    {
        User? existingUser = await userDao.GetByUsernameAsync(username);
        
        if (existingUser == null)
        {
            throw new Exception("User not found");
        }

        if (!existingUser.password.Equals(password))
        {
            throw new Exception("Password mismatch");
        }

        return existingUser;
    }

    public async Task RegisterUser(UserCreationDto user)
    {

        if (string.IsNullOrEmpty(user.UserName))
        {
            throw new ValidationException("Username cannot be null");
        }

        if (string.IsNullOrEmpty(user.Password))
        {
            throw new ValidationException("Password cannot be null");
        }
        // Do more user info validation here
        
        // save to persistence instead of list

        await userDao.CreateAsync(new User
        {
            userName = user.UserName,
            password = user.Password
        });
        
    }
}