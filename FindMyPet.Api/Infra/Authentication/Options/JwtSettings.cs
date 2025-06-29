namespace FindMyPet.Api.Infra.Authentication.Options;

public class JwtSettings
{
    public string SecretKey { get; set; }
    
    public int ExpiryInMinutes { get; set; }
    
    public string Issuer { get; set; }
}