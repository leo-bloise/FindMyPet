namespace FindMyPet.Domain.Entities;

public class Home
{
    public long Id { get; set; }
    
    public User User { get; set; }
    
    public GeoPoint Location { get; set; }
}