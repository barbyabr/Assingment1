using Domain.DTOs;
using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface IUserService
{
    Task CreateAsync(UserCreationDto dto);
    Task <IEnumerable<User>> GetUsersAsync (string? usernameContains = null);
}