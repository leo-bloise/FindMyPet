using FindMyPet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindMyPet.Api.Infra.Database.Configurations;

public class UserConfiguration : BaseConfiguration<User>
{
    public UserConfiguration() : base("users")
    {
    }

    public void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);
        
        ConfigureTelephone(builder);
        ConfigureName(builder);
        ConfigurePassword(builder);
    }

    protected override void ConfigureId(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .HasColumnName("id");
        
        builder.HasKey(x => x.Id)
            .HasName("id");
    }
    
    protected override void ConfigureCreatedAt(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.CreatedAt)
            .HasColumnName("created_at")
            .ValueGeneratedOnAdd();
    }
    
    protected override void ConfigureUpdatedAt(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.UpdatedAt)
            .HasColumnName("updated_at")
            .ValueGeneratedOnAdd();
    }
    
    private void ConfigurePassword(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.Password)
            .HasColumnName("password")
            .IsRequired();
    }

    private void ConfigureName(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.Name)
            .HasColumnName("name")
            .IsRequired();
    }
    
    private void ConfigureTelephone(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.Telephone)
            .HasColumnName("telephone")
            .HasMaxLength(11)
            .IsRequired();
        
        builder.HasIndex(x => x.Telephone).IsUnique();
    }
}