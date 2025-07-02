using FindMyPet.Api.Infra.Database.Entities;
using FindMyPet.Application.Adapters;
using FindMyPet.Domain.Entities;
using NetTopologySuite;
using NetTopologySuite.Geometries;

namespace FindMyPet.Api.Infra.Adapters;

public class HomeAdapter : IHomeAdapter<Home, HomeEf>
{
    private static readonly GeometryFactory _geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
    
    public Home ToEntity(HomeEf model)
    {
        return new Home()
        {
            Id = model.Id,
            User = model.User,
            Location = new GeoPoint(model.Location.Y, model.Location.X)
        };
    }

    public HomeEf ToModel(Home entity)
    {
        return new HomeEf()
        {
            Id = entity.Id,
            User = entity.User,
            Location = _geometryFactory.CreatePoint(new Coordinate(entity.Location.Longitude, entity.Location.Latitude))
        };
    }
}