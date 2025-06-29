namespace FindMyPet.Domain.Exceptions;

public class TelephoneAlreadyTaken : DomainException
{
    public TelephoneAlreadyTaken(string telephone) : base($"Telephone already taken: {telephone}")
    {
    }
}