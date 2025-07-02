using FindMyPet.Api.Infra.Database.Configurations;
using FindMyPet.Api.Infra.Database.Entities;
using FindMyPet.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FindMyPet.Api.Infra.Database;

public class FindMyPetContext : DbContext
{
    public DbSet<User> Users { get; set; }
    
    public DbSet<HomeEf> Homes { get; set; }
    
    public FindMyPetContext(DbContextOptions<FindMyPetContext> options):  base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<HomeEf>().Ignore("UserData");
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new HomeEfConfiguration());
    }
}