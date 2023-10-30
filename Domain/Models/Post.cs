namespace Domain.Models;

public class Post
{
    public int Id { get; set; }
    public User User { get; }
    public string Title { get; }
    public string text { get; }

    public Post(User user, string title, string text)
    {
        this.User = user;
        this.Title = title;
        this.text = text;
    }
    
    
    
}