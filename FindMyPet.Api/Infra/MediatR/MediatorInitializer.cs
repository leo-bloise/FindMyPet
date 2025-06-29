using FindMyPet.Application.Commands;
using FindMyPet.Application.Handler;
using FindMyPet.Domain.Entities;
using MediatR;

namespace FindMyPet.Api.Infra.MediatR;

public static class MediatorInitializer
{
    public static void InitializeMediatR(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IRequestHandler<CreateUserCommand, User>, CreateUserHandler>();
        builder.Services.AddScoped <IRequestHandler<LoginUserCommand, string>, LoginUserHandler>();
        
        builder.Services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
        });
    }
}