using OnRideApp.Models.DomainModel;
using OnRideApp.Models.Dtos.Request;

namespace OnRideApp.Transformer;

public class DriverRequestTransform
{
    public static Driver DriverRequestToDriver(DriverRequest driverRequest)
    {
        return new Driver
        {
            Name = driverRequest.Name,
            Age = driverRequest.Age,
            PanNumber = driverRequest.PanNumber,
            MobNumber = driverRequest.MobNumber,
        };
    }

    public static Cab CabRequestToCab(CabRequest cabRequest)
    {
        return new Cab
        {
            IsAvailable = cabRequest.IsAvailable,
            Number = cabRequest.CabNumber
        };
    }
}
