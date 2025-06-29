namespace FindMyPet.Api.Controllers.DTOs.Output.Base;

public class ApiResponseData<T> : ApiResponse
{
    public T Data { get; set; }
    
    public ApiResponseData(string message, T data) : base(message)
    {
        Data = data;
    }
}