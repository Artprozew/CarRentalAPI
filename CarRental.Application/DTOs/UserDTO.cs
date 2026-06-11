using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CarRental.Application.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(200, ErrorMessage = "Name cannot exceed 200 characters")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [MaxLength(200, ErrorMessage = "Email cannot exceed 200 characters")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [MaxLength(200, ErrorMessage = "Password cannot exceed 200 characters")]
        [MinLength(8, ErrorMessage = "Password must contain at least 8 characters")]
        [NotMapped]
        public string? Password { get; set; }
        [JsonIgnore]
        public bool IsAdmin { get; set; }
    }
}
