using CarRental.Domain.Validations;

namespace CarRental.Domain.Entities
{
    public class Rental
    {
        public uint RentalId { get; private set; }
        public uint CustomerId { get; private set; }
        public uint CarId { get; private set; }
        public DateTime RentalDate { get; private set; }
        public DateTime ReturnDate { get; private set; }
        public bool HasReturned { get; private set; }
        public decimal TotalPrice { get; private set; }

        public Car Car { get; set; }
        public Customer Customer { get; set; }

        public Rental(uint rentalId, uint customerId, uint carId, DateTime rentalDate, DateTime returnDate, bool hasReturned, decimal totalPrice)
        {
            DomainExceptionValidation.When(rentalId < 0, "Rental ID must be a positive number");
            RentalId = rentalId;
            ValidateDomain(customerId, carId, rentalDate, returnDate, hasReturned, totalPrice);
        }

        public Rental(uint customerId, uint carId, DateTime rentalDate, DateTime returnDate, bool hasReturned, decimal totalPrice)
        {
            ValidateDomain(customerId, carId, rentalDate, returnDate, hasReturned, totalPrice);
        }

        public void Update(uint customerId, uint carId, DateTime rentalDate, DateTime returnDate, bool hasReturned, decimal totalPrice)
        {
            ValidateDomain(customerId, carId, rentalDate, returnDate, hasReturned, totalPrice);
        }

        public void ValidateDomain(uint customerId, uint carId, DateTime rentalDate, DateTime returnDate, bool hasReturned, decimal totalPrice)
        {
            DomainExceptionValidation.When(customerId < 0, "Customer ID must be a positive number");
            DomainExceptionValidation.When(carId < 0, "Car ID must be a positive number");

            HasReturned = hasReturned;
            CustomerId = customerId;
            CarId = carId;
            RentalDate = rentalDate;
            ReturnDate = returnDate;
            TotalPrice = totalPrice;
        }
    }
}