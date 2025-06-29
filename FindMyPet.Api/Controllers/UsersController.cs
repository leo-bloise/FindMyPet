using FindMyPet.Api.Controllers.DTOs.Input;
using FindMyPet.Api.Controllers.DTOs.Output;
using FindMyPet.Api.Controllers.DTOs.Output.Base;
using FindMyPet.Application.Commands;
using FindMyPet.Domain.Entities;
using FindMyPet.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FindMyPet.Api.Controllers;

public class UsersController : Controller
{
    public UsersController(IMediator mediator) : base(mediator)
    {
    }

    [Authorize]
    [HttpGet("me")]
    public IActionResult Me()
    {
        User user = GetUser() ?? throw new Unauthorized();
        return Ok(new ApiResponseData<UserCreatedResponseData>("Me", new UserCreatedResponseData(user.Id, user.Name, user.Telephone)));
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserDTO request)
    {
        CreateUserCommand command = new(request.Telephone, request.Password, request.Name);
        User user = await _mediator.Send(command);
        return Created($"users/me", UserCreatedResponse.Adapt(user));
    }
}