using System.ComponentModel.DataAnnotations;

namespace OnRideApp.Models.DomainModel;
public class Location
{
    public int Id { get; set; }
    [Range(-90 , 90)]
    public double Latitude { get; set; }
    [Range(-180, 180)]
    public double Longitude { get; set; }
}
