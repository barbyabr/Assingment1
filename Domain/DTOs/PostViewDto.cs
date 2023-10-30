namespace Domain.DTOs;

public class PostViewDto
{
    public int Id { get; }
    public int? OwnerId { get; set; }
    public string? Username { get; set; }
    public string? Title { get; set; }
    public string? Text { get; set; }
    
    public PostViewDto(int id)
    {
        Id = id;
    }
}