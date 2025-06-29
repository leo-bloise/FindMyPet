using FindMyPet.Application.Commands;
using FindMyPet.Application.Services;
using FindMyPet.Domain.Entities;
using FindMyPet.Domain.Exceptions;
using FindMyPet.Domain.Repositories;
using MediatR;

namespace FindMyPet.Application.Handler;

public class LoginUserHandler : IRequestHandler<LoginUserCommand, string>
{
    private readonly IUserRepository _userRepository;
    
    private readonly ISecurityHasher _securityHasher;
    
    private readonly IJwtService _jwtService;

    public LoginUserHandler(IUserRepository userRepository, ISecurityHasher securityHasher, IJwtService jwtService)
    {
        _userRepository = userRepository;
        _securityHasher = securityHasher;
        _jwtService = jwtService;
    }
    
    public Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        User user = _userRepository.FindByTelephone(request.Telephone) ?? throw new Unauthorized();

        if (!_securityHasher.VerifyHashedPassword(user, request.Password)) throw new Unauthorized();

        return Task.FromResult(_jwtService.GenerateToken(user));
    }
}