using System.ComponentModel.DataAnnotations;

namespace CarRental.Application.DTOs
{
    public class CustomerDTO
    {
        [Key]
        public decimal CustomerId { get; set; }
        [Required]
        [StringLength(200)]
        [MinLength(3)]
        public string? Name { get; set; }
        [Required]
        [StringLength(11)]
        [MinLength(11)]
        public string? Cpf { get; set; }
        [Required]
        [StringLength(200)]
        public string? Address { get; set; }
        [Required]
        [StringLength(100)]
        public string? City { get; set; }
        [Required]
        [StringLength(100)]
        public string? District { get; set; }
        [Required]
        [StringLength(14)]
        public string? PhoneNumber { get; set; }
    }
}