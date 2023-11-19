using System.Text.Json.Serialization;

namespace Domain.Models;

public class User
{
    public int Id { get; set; }
    public string userName { get; set; }
    public string password { get; set; }
    [JsonIgnore]
    
    public ICollection<Post> Posts { get; set; }
    
}