using System.Text.Json;
using Domain.Models;

namespace FileData;

public class FileContext
{
    private const string filePath = "data.json";
    private DataContainer? dataContainer;

    private void LoadData() //private cos' the class is resp for det when to load the data
    {
        if (dataContainer != null) return;
    
        if (!File.Exists(filePath))
        {
            dataContainer = new ()
            {
                Posts = new List<Post>(),
                Users = new List<User>()
            };
            return;
        }
        string content = File.ReadAllText(filePath);
        dataContainer = JsonSerializer.Deserialize<DataContainer>(content);
    }
    
    //The DataContainer is serialized to JSON, then written to the file. Then the field is cleared.
    public void SaveChanges()
    {
        string serialized = JsonSerializer.Serialize(dataContainer, new JsonSerializerOptions
        {
            WriteIndented = true
        });
        File.WriteAllText(filePath, serialized);
        dataContainer = null;
    }
    
    public ICollection<Post> Posts
    {
        get
        {
            LoadData();
            return dataContainer!.Posts;
        }
        
    }

    public ICollection<User> Users
    {
        get
        {
            LoadData();
            return dataContainer!.Users;
        }
    }
    
}