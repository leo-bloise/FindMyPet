using FindMyPet.Api.Infra.Database.Entities;
using FindMyPet.Application.Adapters;
using FindMyPet.Domain.Entities;

namespace FindMyPet.Api.Infra.Adapters;

public static class AdapterInitialization
{
    public static void InitializeAdapters(this WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<IHomeAdapter<Home, HomeEf>, HomeAdapter>();
    }
}