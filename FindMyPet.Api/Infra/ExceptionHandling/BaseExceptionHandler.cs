using FindMyPet.Api.Controllers.DTOs.Output.Base;
using Microsoft.AspNetCore.Diagnostics;

namespace FindMyPet.Api.Infra.ExceptionHandling;

public class BaseExceptionHandler(ILogger<BaseExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        logger.LogCritical(exception, exception.Message);
        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        await httpContext.Response.WriteAsJsonAsync(new ApiResponse("Internal message error"), cancellationToken);
        return true;
    }
}