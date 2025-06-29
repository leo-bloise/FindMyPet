using FindMyPet.Api.Controllers.DTOs.Output.Base;
using FindMyPet.Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace FindMyPet.Api.Infra.ExceptionHandling;

public class DomainExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is not DomainException) return false;
        httpContext.Response.StatusCode = StatusCodes.Status422UnprocessableEntity;
        await httpContext.Response.WriteAsJsonAsync(new ApiResponse(exception.Message), cancellationToken);
        return true;
    }
}