namespace FindMyPet.Domain.Exceptions;

public class Unauthorized : DomainException
{
    public Unauthorized() : base("Unauthorized")
    {
    }
}