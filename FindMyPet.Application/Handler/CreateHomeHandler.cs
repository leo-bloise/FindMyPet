using FindMyPet.Application.Commands;
using FindMyPet.Domain.Entities;
using FindMyPet.Domain.Exceptions;
using FindMyPet.Domain.Repositories;
using MediatR;

namespace FindMyPet.Application.Handler;

public class CreateHomeHandler : IRequestHandler<CreateHomeCommand, Home>
{
    private readonly IHomeRepository _homeRepository;
    
    private readonly IUserRepository _userRepository;

    public CreateHomeHandler(IHomeRepository homeRepository, IUserRepository userRepository)
    {
        _homeRepository = homeRepository;
        _userRepository = userRepository;
    }

    private User? GetUser(long userId)
    {
        return _userRepository.FindById(userId);
    }
    
    public Task<Home> Handle(CreateHomeCommand request, CancellationToken cancellationToken)
    {
        User user = GetUser(request.UserId) ?? throw new Unauthorized();

        if (_homeRepository.ExistsForUser(user))
        {
            throw new HomeAlreadyDefined(user);
        }

        Home home = new()
        {
            User = user,
            Location = new GeoPoint(request.Latitude, request.Longitude)
        };

        return Task.FromResult(_homeRepository.Create(home));
    }
}