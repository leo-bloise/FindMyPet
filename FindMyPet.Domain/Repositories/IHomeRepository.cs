using FindMyPet.Domain.Entities;

namespace FindMyPet.Domain.Repositories;

public interface IHomeRepository
{
    public Home Create(Home home);
    
    public bool ExistsForUser(User user);
}