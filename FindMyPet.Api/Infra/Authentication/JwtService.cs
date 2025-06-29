using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FindMyPet.Api.Infra.Authentication.Options;
using FindMyPet.Application.Services;
using FindMyPet.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace FindMyPet.Api.Infra.Authentication;

public class JwtService : IJwtService
{
    private readonly JwtSettings _jwtSettings;

    public JwtService(IOptions<JwtSettings> jwtSettings)
    {
        _jwtSettings = jwtSettings.Value;
    }

    private Claim[] GenerateClaims(User user)
    {
        return new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.PhoneNumber, user.Telephone),
            new Claim(JwtRegisteredClaimNames.Name, user.Name)
        };
    }

    public SigningCredentials GenerateSigningCredentials()
    {
        SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
        return new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
    }

    public DateTime GenerateTokenExpireDate()
    {
        return DateTime.Now.AddMinutes(_jwtSettings.ExpiryInMinutes);
    }
    
    public string GenerateToken(User user)
    {
        JwtSecurityToken token = new(
            issuer: _jwtSettings.Issuer,
            claims: GenerateClaims(user),
            expires: GenerateTokenExpireDate(),
            signingCredentials: GenerateSigningCredentials());
        
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}