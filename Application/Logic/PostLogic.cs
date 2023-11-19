using Application.DaoInterfaces;
using Application.LoginInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace Application.Logic;

public class PostLogic : IPostLogic
{
    private readonly IPostDao postDao;
    private readonly IUserDao userDao;

    public PostLogic(IPostDao postDao, IUserDao userDao)
    {
        this.postDao = postDao;
        this.userDao = userDao;
    }
    
    
    public async Task<Post> CreateAsync(PostCreationDto dto)
    {
        User? user = await userDao.GetByUsernameAsync(dto.UserName);
        if (user == null)
        {
            throw new Exception($"User with {dto.UserName} was not found.");
        }

        ValidatePost(dto);
        Post post = new Post(user.Id, dto.Title,dto.Text);
        Post created = await postDao.CreateAsync(post);
        return created;
    }

    public Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchParameters)
    {
        return postDao.GetAsync(searchParameters);
    }

    
    public async Task<PostBasicDto> GetByIdAsync(int id)
    {
        Post? post = await postDao.GetByIdAsync(id);
        if (post == null)
        {
            throw new Exception($"Post with id {id} was not found");
        }

        return new PostBasicDto(post.Id, post.User.userName, post.Title, post.Text);
    }

    private void ValidatePost(PostCreationDto dto)
    {
        if (string.IsNullOrEmpty(dto.Title)) throw new Exception("Title cannot be empty.");
        if(string.IsNullOrEmpty(dto.Text)) throw new Exception("Text field cannot be empty.");
    }
}