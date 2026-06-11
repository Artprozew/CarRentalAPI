namespace CarRental.Application.DTOs
{
    public class RentalDTO
    {
        public uint RentalId { get; set; }
        public uint CustomerId { get; set; }
        public uint CarId { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool HasReturned { get; set; }
        public decimal TotalPrice { get; set; }
        public CustomerDTO CustomerDTO { get; set; }
        public CarDTO CarDTO { get; set; }
    }
}
