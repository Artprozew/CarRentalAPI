using System.ComponentModel.DataAnnotations;

namespace CarRental.API.Models
{
    public class PaginationParams
    {
        [Range(1, int.MaxValue)]
        public int PageNumber { get; set; }
        [Range(1, 50, ErrorMessage = "PageSize cannot exceed 50")]
        public int PageSize { get; set; }
    }
}
