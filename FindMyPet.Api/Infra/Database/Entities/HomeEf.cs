using FindMyPet.Domain.Entities;
using NetTopologySuite.Geometries;

namespace FindMyPet.Api.Infra.Database.Entities;

public class HomeEf
{
    public long Id { get; set; }
    
    public User User { get; set; }
    
    public Point Location { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime UpdatedAt { get; set; }
}