using FindMyPet.Application.Services;

namespace FindMyPet.Api.Infra.Security;

public static class SecurityInitialization
{
    public static void InitializeSecurity(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ISecurityHasher, IdentitySecurityHasher>();
    }
}