using FindMyPet.Domain.Entities;

namespace FindMyPet.Application.Services;

public interface IJwtService
{
    public string GenerateToken(User user);
}