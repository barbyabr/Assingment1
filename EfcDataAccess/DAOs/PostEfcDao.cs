using Application.DaoInterfaces;
using Domain.DTOs;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfcDataAccess.DAOs;

public class PostEfcDao : IPostDao
{
    private readonly PostContext context;

    public PostEfcDao(PostContext context)
    {
        this.context = context;
    }
    public async Task<Post> CreateAsync(Post post)
    {
        EntityEntry<Post> added = await context.Posts.AddAsync(post);
        await context.SaveChangesAsync();
        return added.Entity;
    }

    public async Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchParams)
    {
        IQueryable<Post> query = context.Posts.Include(post => post.User).AsQueryable();
    
        if (!string.IsNullOrEmpty(searchParams.Username))
        {
            // we know username is unique, so just fetch the first
            query = query.Where(post =>
                post.User.userName.ToLower().Equals(searchParams.Username.ToLower()));
        }
    
        if (searchParams.UserId != null)
        {
            query = query.Where(t => t.User.Id == searchParams.UserId);
        }
    
        if (!string.IsNullOrEmpty(searchParams.TitleContains))
        {
            query = query.Where(t =>
                t.Title.ToLower().Contains(searchParams.TitleContains.ToLower()));
        }

        List<Post> result = await query.ToListAsync();
        return result;
    }
    public async Task<Post?> GetByIdAsync(int id)
    {
        Post? found = await context.Posts
            .AsNoTracking()
            .Include(post => post.User)
            .SingleOrDefaultAsync(post => post.Id == id);
        return found;
    }
}