namespace Domain.DTOs;

public class PostBasicDto
{
    public int Id { get; }
    public string Username { get; }
    public string Title { get; }
    public string Text { get;  }

    public PostBasicDto(int id, string userName, string title, string text)
    {
        Id = id;
        Username = userName;
        Title = title;
        Text = text;
    }
}