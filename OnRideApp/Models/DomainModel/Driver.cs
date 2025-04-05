using System.ComponentModel.DataAnnotations;
using Microsoft.OpenApi.MicrosoftExtensions;
using OnRideApp.Common;

namespace OnRideApp.Models.DomainModel;

public class Driver
{
    public int Id { get; set; }
    [StringLength(50, ErrorMessage = "Name length must be less than 50 characters!")]
    public string Name { get; set; }
    [Range(1, 110, ErrorMessage = "Age must be between 1 to 110")]
    public int Age { get; set; }
    [StringLength(10, ErrorMessage = "Pan number is not valid!")]
    public string PanNumber { get; set; }
    [Phone]
    [RegularExpression(RegexPatterns.PhoneNumberPattern, ErrorMessage = "Mobile number is not valid!")]
    public string MobNumber { get; set; }
    [Range(1, 5, ErrorMessage = "Rating must be between 1 to 5!")]
    public double Rating { get; set; }
}
