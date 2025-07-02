using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindMyPet.Api.Infra.Database.Configurations;

public abstract class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : class
{ 
    private string _columnName;

    protected BaseConfiguration(string columnName)
    {
        _columnName = columnName;
    }

    protected abstract void ConfigureId(EntityTypeBuilder<TEntity> builder);

    protected abstract void ConfigureCreatedAt(EntityTypeBuilder<TEntity> builder);

    protected abstract void ConfigureUpdatedAt(EntityTypeBuilder<TEntity> builder);
    
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.ToTable(_columnName);
        
        ConfigureId(builder);
        ConfigureCreatedAt(builder);
        ConfigureUpdatedAt(builder);
    }
}