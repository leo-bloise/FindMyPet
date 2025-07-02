using FindMyPet.Api.Infra.Database.Repositories;
using FindMyPet.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FindMyPet.Api.Infra.Database;

public static class DatabaseInitializer
{
    public static void InitializeDbContext(this WebApplicationBuilder app)
    {
        app.Services.AddDbContext<FindMyPetContext>(options =>
        {
            options.UseNpgsql(app.Configuration.GetConnectionString("DefaultConnection"), ngpsql => ngpsql.UseNetTopologySuite());
        });
        
        app.Services.AddScoped<IUserRepository, EfUserRepository>();
        app.Services.AddScoped<IHomeRepository, EfHomeRepository>();
    }
}