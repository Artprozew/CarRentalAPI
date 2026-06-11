using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CarRental.Application.DTOs
{
    public class RentalPostDTO
    {
        [Required(ErrorMessage = "CustomerId is required")]
        [Range(1, int.MaxValue, ErrorMessage = "The ID range is not valid")]
        public uint CustomerId { get; set; }
        [Required(ErrorMessage = "CarId is required")]
        [Range(1, int.MaxValue, ErrorMessage = "The ID range is not valid")]
        public uint CarId { get; set; }
        [Required(ErrorMessage = "ReturnDate is required")]
        public DateTime ReturnDate { get; set; }
        [Required(ErrorMessage = "TotalPrice is required")]
        public decimal TotalPrice { get; set; }
        [JsonIgnore]
        public DateTime RentalDate { get; set; }
        [JsonIgnore]
        public bool HasReturned { get; set; }
    }
}
