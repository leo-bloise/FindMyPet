using FindMyPet.Api.Controllers.DTOs.Output.Base;
using FindMyPet.Domain.Entities;

namespace FindMyPet.Api.Controllers.DTOs.Output;

public record HomeCreatedResponseData(
    double Latitude,
    double Longitude
)
{
    public static HomeCreatedResponseData Create(Home home)
    {
        return new HomeCreatedResponseData(home.Location.Latitude, home.Location.Longitude);
    }
}

public class HomeCreatedResponse : ApiResponseData<HomeCreatedResponseData>
{
    public HomeCreatedResponse(string message, HomeCreatedResponseData data) : base(message, data) {}

    public static HomeCreatedResponse FromHome(Home home)
    {
        return new HomeCreatedResponse("Home saved!", HomeCreatedResponseData.Create(home));
    }
}