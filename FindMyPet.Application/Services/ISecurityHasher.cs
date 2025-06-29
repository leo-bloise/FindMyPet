using FindMyPet.Domain.Entities;

namespace FindMyPet.Application.Services;

public interface ISecurityHasher
{
    public string HashPassword(User user, string password);
    
    public bool VerifyHashedPassword(User user, string password);
}