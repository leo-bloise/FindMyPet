using FindMyPet.Domain.Entities;
using MediatR;

namespace FindMyPet.Application.Commands;

public record CreateUserCommand(
    string Telephone,
    string Password,
    string Name) : IRequest<User> {  }
    