using FindMyPet.Api.Controllers.DTOs.Input;
using FindMyPet.Api.Controllers.DTOs.Output;
using FindMyPet.Application.Commands;
using FindMyPet.Domain.Entities;
using FindMyPet.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FindMyPet.Api.Controllers;

[Authorize]
public class HomesController : Controller
{
    public HomesController(IMediator mediator) : base(mediator)
    {
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateHomeDTO homeRequest)
    {
        User user = GetUser() ?? throw new Unauthorized();

        CreateHomeCommand command = new(homeRequest.Latitude, homeRequest.Longitude, user.Id);

        Home home = await _mediator.Send(command);

        return Created("/home", HomeCreatedResponse.FromHome(home));
    }
}