using Domain.DTOs;
using Domain.Models;

namespace Application.LoginInterfaces;

public interface IPostLogic
{
    Task<Post> CreateAsync(PostCreationDto dto);
    Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchParameters);
    Task<PostBasicDto> GetByIdAsync(int id);

}