namespace FindMyPet.Application.Adapters;

public interface IHomeAdapter<TEntity, TModel>
{
    public TEntity ToEntity(TModel model);
    
    public TModel ToModel(TEntity entity);
}