using System.ComponentModel.DataAnnotations;
using OnRideApp.Models.DomainModel;

namespace OnRideApp.Models.Dtos.Request;

public class DriverRequest
{
    public string Name { get; set; }
    public int Age { get; set; }
    [RegularExpression(@"^[A-Z]{5}[0-9]{4}[A-Z]{1}$")]
    public string PanNumber { get; set; }
    [Phone]
    public string MobNumber { get; set; }
    public CabRequest Cab { get; set; }
}
