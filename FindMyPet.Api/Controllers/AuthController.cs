using FindMyPet.Api.Controllers.DTOs.Input;
using FindMyPet.Api.Controllers.DTOs.Output.Base;
using FindMyPet.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FindMyPet.Api.Controllers;

public class AuthController : Controller
{
    public AuthController(IMediator mediator) : base(mediator)
    {
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserDTO request)
    {
        LoginUserCommand command = new(request.Telephone, request.Password);
        
        string token = await _mediator.Send(command);
        
        return Ok(new ApiResponseData<string>("Login successful", token));
    }
}