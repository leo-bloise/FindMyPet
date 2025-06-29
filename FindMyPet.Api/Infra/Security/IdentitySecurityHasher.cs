using FindMyPet.Application.Services;
using FindMyPet.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace FindMyPet.Api.Infra.Security;

public class IdentitySecurityHasher : ISecurityHasher
{
    private readonly PasswordHasher<User> _passwordHasher = new();
    public string HashPassword(User user, string password)
    {
        return _passwordHasher.HashPassword(user, password);
    }

    public bool VerifyHashedPassword(User user, string password)
    {
        PasswordVerificationResult result = _passwordHasher.VerifyHashedPassword(user, user.Password, password);
        
        return result == PasswordVerificationResult.Success;
    }
}