using FindMyPet.Domain.Entities;
using MediatR;

namespace FindMyPet.Application.Commands;

public record CreateHomeCommand(double Latitude, double Longitude, long UserId) : IRequest<Home>;