namespace FindMyPet.Api.Controllers.DTOs.Output.Base;

public class ApiResponse
{
    public string Message { get; set; }

    public long Time { get; set; }

    public ApiResponse(string message)
    {
        Message = message;
        Time = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    }
}