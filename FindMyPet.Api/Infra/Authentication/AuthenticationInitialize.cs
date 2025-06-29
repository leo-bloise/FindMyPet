using System.Text;
using FindMyPet.Api.Infra.Authentication.Options;
using FindMyPet.Application.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace FindMyPet.Api.Infra.Authentication;

public static class AuthenticationInitialize
{
    public static void InitializeAuthentication(this WebApplicationBuilder builder)
    {
        JwtSettings jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>() ?? throw new ArgumentNullException("JwtSettings must be a valid value");
        
        builder.Services.Configure<JwtSettings>(options => builder.Configuration.GetSection("JwtSettings").Bind(options));

        builder.Services.AddScoped<IJwtService, JwtService>();
        
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new()
                {
                    ValidIssuer = jwtSettings.Issuer,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey)),
                };
            });
    }
}