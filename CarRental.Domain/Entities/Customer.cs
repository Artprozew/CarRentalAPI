using CarRental.Domain.Validations;

namespace CarRental.Domain.Entities
{
    public class Customer
    {
        public uint CustomerId { get; private set; }
        public string Name { get; private set; }
        public string Cpf { get; private set; }
        public string Address { get; private set; }
        public string City { get; private set; }
        public string District { get; private set; } // Rename to neighborhood
        public string PhoneNumber { get; private set; }

        public ICollection<Rental> Rentals { get; set; }

        public Customer(uint customerId, string name, string cpf, string address, string city,
            string district, string phoneNumber)
        {
            DomainExceptionValidation.When(customerId < 0, "Customer ID must be a positive number");
            CustomerId = customerId;
            ValidateDomain(name, cpf, address, city, district, phoneNumber);
        }

        public Customer(string name, string cpf, string address, string city,
            string district, string phoneNumber)
        {
            ValidateDomain(name, cpf, address, city, district, phoneNumber);
        }

        public void Update(string name, string cpf, string address, string city,
            string district, string phoneNumber)
        {
            ValidateDomain(name, cpf, address, city, district, phoneNumber);
        }

        public void ValidateDomain(string name, string cpf, string address, string city,
            string district, string phoneNumber)
        {
            DomainExceptionValidation.When(name.Length > 200, "Name cannot exceed 200 characters");
            DomainExceptionValidation.When(cpf.Length != 11, "CPF must have 11 characters");
            DomainExceptionValidation.When(address.Length > 200, "Address cannot exceed 200 characters");
            DomainExceptionValidation.When(city.Length == 100, "City cannot exceed 100 characters");
            DomainExceptionValidation.When(district.Length == 100, "District cannot exceed 100 characters");
            DomainExceptionValidation.When(phoneNumber.Length > 14, "Phone Number cannot exceed 14 characters");

            Name = name;
            Cpf = cpf;
            Address = address;
            City = city;
            District = district;
            PhoneNumber = phoneNumber;
        }
    }
}