using System.ComponentModel.DataAnnotations;

namespace CarRental.Application.DTOs
{
    public class CarDTO
    {
        public uint CarId { get; set; }
        [MaxLength(25, ErrorMessage = "CarModel must not exceed 25 characters")]
        [Required(ErrorMessage = "CarModel is required")]
        public string CarModel { get; set; }
        [MaxLength(25, ErrorMessage = "Manufacturer must not exceed 25 characters")]
        [Required(ErrorMessage = "Manufacturer is required")]
        public string Manufacturer { get; set; }
        [MaxLength(15, ErrorMessage = "CarType must not exceed 15 characters")]
        [Required(ErrorMessage = "CarType is required")]
        public string CarType { get; set; }
        [MaxLength(15, ErrorMessage = "Plate must not exceed 15 characters")]
        [Required(ErrorMessage = "Plate is required")]
        public string Plate { get; set; }
        [Required(ErrorMessage = "CarYear is required")]
        public DateTime CarYear { get; set; }
        [MaxLength(15, ErrorMessage = "Color must not exceed 15 characters")]
        [Required(ErrorMessage = "Color is required")]
        public string Color { get; set; }
        [Required(ErrorMessage = "Mileage is required")]
        public uint Mileage { get; set; }
        [Required(ErrorMessage = "RentPrice is required")]
        public decimal RentPrice { get; set; }
    }
}
