using FindMyPet.Domain.Entities;

namespace FindMyPet.Domain.Exceptions;

public class HomeAlreadyDefined : DomainException
{
    public HomeAlreadyDefined(User user) : base($"User {user.Name} already has a Home")
    {
    }
}