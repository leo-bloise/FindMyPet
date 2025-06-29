using FindMyPet.Api.Infra.Database.Configurations;
using FindMyPet.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FindMyPet.Api.Infra.Database;

public class FindMyPetContext : DbContext
{
    public DbSet<User> Users { get; set; }
    
    public FindMyPetContext(DbContextOptions<FindMyPetContext> options):  base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
}