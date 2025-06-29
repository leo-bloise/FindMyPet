using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using FindMyPet.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FindMyPet.Api.Controllers;

[ApiController]
[Route("[controller]")]
public abstract class Controller : ControllerBase
{
    protected readonly IMediator _mediator;

    public Controller(IMediator mediator)
    {
        _mediator = mediator;
    }

    public User? GetUser()
    {
        string? name = HttpContext.User.FindFirst(JwtRegisteredClaimNames.Name)?.Value;
        string? telephone = HttpContext.User.FindFirst(JwtRegisteredClaimNames.PhoneNumber)?.Value;
        string? id = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (name == null || telephone == null || id == null) return null;

        return new User()
        {
            Name = name,
            Telephone = telephone,
            Id = long.Parse(id),
        };
    }
}