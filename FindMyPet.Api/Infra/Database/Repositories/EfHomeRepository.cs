using FindMyPet.Api.Infra.Database.Entities;
using FindMyPet.Application.Adapters;
using FindMyPet.Domain.Entities;
using FindMyPet.Domain.Repositories;

namespace FindMyPet.Api.Infra.Database.Repositories;

public class EfHomeRepository : IHomeRepository
{
    private readonly IHomeAdapter<Home, HomeEf> _homeAdapter;
    
    private readonly FindMyPetContext _context;

    public EfHomeRepository(IHomeAdapter<Home, HomeEf> homeAdapter, FindMyPetContext context)
    {
        _homeAdapter = homeAdapter;
        _context = context;
    }
    
    public Home Create(Home home)
    {
        HomeEf model = _homeAdapter.ToModel(home);
        
        _context.Homes.Add(model);
        _context.SaveChanges();
        
        return _homeAdapter.ToEntity(model);
    }

    public bool ExistsForUser(User user)
    {
        return _context.Homes.Any(h => h.User.Id == user.Id);
    }
}