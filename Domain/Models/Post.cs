using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Post
{
    [Key]
    public int Id { get; set; }
    public User User { get;  set; }
    public int UserId { get; set; }
    [MaxLength(50)]
    public string Title { get;  set; }
    [MaxLength(100)]
    public string Text { get;  set; }

   // public Post(User user, string title, string text)
   // {
   //     this.User = user;
   //     this.Title = title;
   //     this.Text = text;
   // }

    public Post(int ownerId, string title, string text)
    {
        UserId = ownerId;
        Title = title;
        Text = text;
    }
    
    public Post(){}
    
}