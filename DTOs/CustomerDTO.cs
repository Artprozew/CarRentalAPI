using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CarRental.API.DTOs
{
    public class CustomerDTO
    {
        [Key]
        public decimal CustomerId { get; set; }
        [Required]
        [StringLength(200)]
        [MinLength(3)]
        [Unicode(false)]
        public string? CustomerName { get; set; }
        [Required]
        [StringLength(14)]
        [MinLength(14)]
        [Unicode(false)]
        public string? Cpf { get; set; }
        [Required]
        [StringLength(200)]
        [Unicode(false)]
        public string? Address { get; set; }
        [Required]
        [StringLength(100)]
        [Unicode(false)]
        public string? City { get; set; }
        [Required]
        [StringLength(100)]
        [Unicode(false)]
        public string? District { get; set; }
        [Required]
        [StringLength(14)]
        [Unicode(false)]
        public string? PhoneNumber { get; set; }

    }
}
