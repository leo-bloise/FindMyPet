using System.Diagnostics;
using FindMyPet.Api.Controllers.DTOs.Output.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FindMyPet.Api.Controllers;

public class PingController : Controller
{
    public PingController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    public IActionResult Ping()
    {
        Process process = Process.GetCurrentProcess();
        
        return Ok(new ApiResponseData<object>("Pong", new
        {
            MemoryAllocated = Math.Round((double) process.WorkingSet64 / (1024 * 1024), 2), 
            HeapMemoryUsed = Math.Round((double) GC.GetTotalMemory(false) / (1024 * 1024), 2),
        }));
    }
}