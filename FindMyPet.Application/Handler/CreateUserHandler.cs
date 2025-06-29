using FindMyPet.Application.Commands;
using FindMyPet.Application.Services;
using FindMyPet.Domain.Entities;
using FindMyPet.Domain.Exceptions;
using FindMyPet.Domain.Repositories;
using MediatR;

namespace FindMyPet.Application.Handler;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, User>
{
    private readonly ISecurityHasher _hasher;
    private readonly IUserRepository _userRepository;

    public CreateUserHandler(IUserRepository userRepository, ISecurityHasher hasher)
    {
        _userRepository = userRepository;
        _hasher = hasher;
    }

    public Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        if (_userRepository.ExistsByTelephone(request.Telephone))
        {
            throw new TelephoneAlreadyTaken(request.Telephone);
        };

        User user = new User()
        {
            Telephone = request.Telephone,
            Name = request.Name
        };
        
        user.Password = _hasher.HashPassword(user, request.Password);

        return Task.FromResult(_userRepository.CreateUser(user));
    }
}