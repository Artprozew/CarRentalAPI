using System.ComponentModel.DataAnnotations;

namespace CarRental.Application.DTOs
{
    public class RentalPutDTO
    {
        [Required(ErrorMessage = "RentalId is required")]
        public uint RentalId { get; set; }
        [Required(ErrorMessage = "ReturnDate is required")]
        public DateTime ReturnDate { get; set; }
        [Required(ErrorMessage = "HasReturned is required")]
        public bool HasReturned { get; set; }
        [Required(ErrorMessage = "TotalPrice is required")]
        public decimal TotalPrice { get; set; }
    }
}
