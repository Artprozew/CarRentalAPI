using CarRental.Domain.Validations;

namespace CarRental.Domain.Entities
{
    public class Car
    {
        public uint CarId { get; private set; }
        public string CarModel { get; private set; }
        public string Manufacturer { get; private set; }
        public string CarType { get; private set; }
        public string Plate { get; private set; }
        public DateTime CarYear { get; private set; }
        public string Color { get; private set; }
        public uint Mileage { get; private set; }
        public decimal RentPrice { get; private set; }

        public ICollection<Rental> Rentals { get; set; }

        public Car(uint id, string carModel, string manufacturer, string carType, string plate,
            DateTime carYear, string color, uint mileage, decimal rentPrice)
        {
            DomainExceptionValidation.When(id < 0, "ID must be a positive integer");
            CarId = id;
            ValidateDomain(carModel, manufacturer, carType, plate, carYear, color, mileage, rentPrice);
        }

        public Car(string carModel, string manufacturer, string carType, string plate,
            DateTime carYear, string color, uint mileage, decimal rentPrice)
        {
            ValidateDomain(carModel, manufacturer, carType, plate,  carYear, color, mileage, rentPrice);
        }

        public void Update(string carModel, string manufacturer, string carType, string plate,
            DateTime carYear, string color, uint mileage, decimal rentPrice)
        {
            ValidateDomain(carModel, manufacturer, carType, plate, carYear, color, mileage, rentPrice);
        }

        public void ValidateDomain(string carModel, string manufacturer, string carType, string plate,
            DateTime carYear, string color, uint mileage, decimal rentPrice)
        {
            DomainExceptionValidation.When(carModel.Length > 50, "Model name cannot exceed 50 characters");
            DomainExceptionValidation.When(manufacturer.Length > 50, "Manufacturer name cannot exceed 50 characters");
            DomainExceptionValidation.When(carType.Length > 20, "Car Type cannot exceed 20 characters");
            DomainExceptionValidation.When(plate.Length > 15, "Plate cannot exceed 15 characters");
            DomainExceptionValidation.When(color.Length > 20, "Color cannot exceed 20 characters");

            CarModel = carModel;
            Manufacturer = manufacturer;
            CarType = carType;
            Plate = plate;
            CarYear = carYear;
            Color = color;
            Mileage = mileage;
            RentPrice = rentPrice;
        }
    }
}