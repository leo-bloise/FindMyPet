using FindMyPet.Api.Infra.Adapters;
using FindMyPet.Api.Infra.Authentication;
using FindMyPet.Api.Infra.Controllers;
using FindMyPet.Api.Infra.Database;
using FindMyPet.Api.Infra.ExceptionHandling;
using FindMyPet.Api.Infra.MediatR;
using FindMyPet.Api.Infra.Security;

namespace FindMyPet.Api;

public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
        
        builder.InitializeAndSetupController();
        builder.InitializeDbContext();
        builder.InitializeSecurity();
        builder.InitializeMediatR();
        builder.InitializeAuthentication();
        builder.InitializeAndSetupController();
        builder.InitializeExceptionHandling();
        builder.InitializeAdapters();
        
        WebApplication app = builder.Build();

        app.UseAuthorization();
        app.UseExceptionHandler(handler =>
        {
            
        });
        
        app.MapControllers();
        
        app.Run();
    }
}