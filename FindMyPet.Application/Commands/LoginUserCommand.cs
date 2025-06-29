using MediatR;

namespace FindMyPet.Application.Commands;

public record LoginUserCommand(
    string Telephone,
    string Password) : IRequest<string>;