using FindMyPet.Api.Controllers.DTOs.Output.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FindMyPet.Api.Infra.Filters;

public class ValidationFilter : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if(context.ModelState.IsValid) return;

        Dictionary<string, string[]> errors = context.ModelState
            .Where(ms => ms.Value.Errors.Any())
            .ToDictionary(
                kvp => ConverToCamelCase(kvp.Key),
                kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
            );

        context.Result = new UnprocessableEntityObjectResult(new ApiResponseData<Dictionary<string, string[]>>("Invalid object", errors));
    }

    private string ConverToCamelCase(string input)
    {
        return Char.ToLowerInvariant(input[0]) + input.Substring(1);
    }
}