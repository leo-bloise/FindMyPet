using FindMyPet.Domain.Entities;

namespace FindMyPet.Domain.Repositories;

public interface IUserRepository
{
    public bool ExistsByTelephone(string telephone);
    
    public User CreateUser(User user);
    
    public User? FindByTelephone(string telephone);
}