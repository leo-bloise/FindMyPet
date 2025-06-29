using FindMyPet.Api.Infra.Filters;
using Microsoft.AspNetCore.Mvc;

namespace FindMyPet.Api.Infra.Controllers;

public static class ControllerInitialize
{
    public static void InitializeAndSetupController(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<ApiBehaviorOptions>(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        });

        builder.Services.AddControllers(options =>
        {
            options.Filters.Add<ValidationFilter>();
        });
    }
}