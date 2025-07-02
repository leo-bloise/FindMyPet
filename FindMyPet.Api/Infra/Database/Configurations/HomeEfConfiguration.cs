using FindMyPet.Api.Infra.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindMyPet.Api.Infra.Database.Configurations;

public class HomeEfConfiguration : BaseConfiguration<HomeEf>
{
    public HomeEfConfiguration(): base("homes") {}

    protected override void ConfigureId(EntityTypeBuilder<HomeEf> builder)
    {
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .HasColumnName("id");
        
        builder.HasKey(x => x.Id)
            .HasName("id");
    }
    
    protected override void ConfigureCreatedAt(EntityTypeBuilder<HomeEf> builder)
    {
        builder.Property(x => x.CreatedAt)
            .HasColumnName("created_at")
            .ValueGeneratedOnAdd();
    }
    
    protected override void ConfigureUpdatedAt(EntityTypeBuilder<HomeEf> builder)
    {
        builder.Property(x => x.UpdatedAt)
            .HasColumnName("updated_at")
            .ValueGeneratedOnAdd();
    }

    public override void Configure(EntityTypeBuilder<HomeEf> builder)
    {
        base.Configure(builder);
        
        ConfigureForeingKey(builder);
        ConfigureLocation(builder);
    }

    private void ConfigureLocation(EntityTypeBuilder<HomeEf> builder)
    {
        builder.Property(h => h.Location)
            .HasColumnName("location")
            .HasColumnType("geometry (Point, 4326)")
            .IsRequired();
    }
    
    private void ConfigureForeingKey(EntityTypeBuilder<HomeEf> builder)
    {
        builder.HasOne(h => h.User)
            .WithOne()
            .HasForeignKey<HomeEf>("user_id")
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}