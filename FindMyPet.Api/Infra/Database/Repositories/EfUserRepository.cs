using FindMyPet.Domain.Entities;
using FindMyPet.Domain.Repositories;

namespace FindMyPet.Api.Infra.Database.Repositories;

public class EfUserRepository : IUserRepository
{
    private readonly FindMyPetContext _context;

    public EfUserRepository(FindMyPetContext context)
    {
        _context = context;
    }
    
    public bool ExistsByTelephone(string telephone)
    {
        return _context.Users.Any(user => user.Telephone == telephone);
    }

    public User CreateUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
        
        return user;
    }

    public User? FindByTelephone(string telephone)
    {
        return _context.Users.FirstOrDefault(u => u.Telephone == telephone);
    }
}