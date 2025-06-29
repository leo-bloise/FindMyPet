namespace FindMyPet.Domain.Entities;

public class User
{
    public long Id { get; set; }
    
    public string Telephone { get; set; }
    
    public string Name { get; set; }
    
    public string Password { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime UpdatedAt { get; set; }

    public User() { }
    
    public User( long id, string telephone, string name, string password, DateTime createdAt, DateTime updatedAt )
    {
        Id = id;
        Telephone = telephone;
        Name = name;
        Password = password;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }
}