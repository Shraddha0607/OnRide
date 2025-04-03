using System.ComponentModel.DataAnnotations;
using OnRideApp.Models.MyEnums;

namespace OnRideApp.Models.Dtos.Request
{
    public class CabRequest
    {
        [MaxLength(5, ErrorMessage = "Invalid cab number!")]
        public string CabNumber { get; set; }
        public bool IsAvailable { get; set; }
        public int CabSpecificationId { get; set; }
    }
}
