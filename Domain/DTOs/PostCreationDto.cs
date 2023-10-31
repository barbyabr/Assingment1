namespace Domain.DTOs;

public class PostCreationDto
{
    public String UserName { get; }
    public string Title { get; }
    public string Text { get; }

    public PostCreationDto(string userName, string title, string text)
    {
        UserName = userName;
        Title = title;
        Text = text;
    }
}