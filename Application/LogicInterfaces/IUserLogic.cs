using Domain.DTOs;
using Domain.Models;

namespace Application.LoginInterfaces;

public interface IUserLogic
{
    Task<User> CreateAsync(UserCreationDto userToCreate);
    public Task<IEnumerable<User>> GetAsync(SearchUserParametersDto searchParameters);
}