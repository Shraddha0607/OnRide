using System.ComponentModel.DataAnnotations;

namespace OnRideApp.Models.Dtos.Request;

public class ReviewRequest
{
    [Range(1, 5)]
    public int rating { get; set; }
    public string comment { get; set; }
}
