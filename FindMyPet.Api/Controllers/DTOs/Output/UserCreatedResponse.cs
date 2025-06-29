using FindMyPet.Api.Controllers.DTOs.Output.Base;
using FindMyPet.Domain.Entities;

namespace FindMyPet.Api.Controllers.DTOs.Output;

public record UserCreatedResponseData(long Id, string Name, string Telephone)
{
    public static UserCreatedResponseData Create(User user)
    {
        return new UserCreatedResponseData(user.Id, user.Name, user.Telephone);
    }
}

public class UserCreatedResponse : ApiResponseData<UserCreatedResponseData>
{
    public UserCreatedResponse(string message, UserCreatedResponseData data) : base(message, data)
    {
    }

    public static UserCreatedResponse Adapt(User user)
    {
        return new UserCreatedResponse("User created successfully", UserCreatedResponseData.Create(user));
    }
}