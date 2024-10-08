using CarRental.Domain.Validations;

namespace CarRental.Domain.Entities
{
    public class User
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public byte[] PasswordHash { get; private set; }
        public byte[] PasswordSalt { get; private set; }
        public bool IsAdmin { get; private set; }

        public User(int id, string name, string email)
        {
            DomainExceptionValidation.When(id < 0, "Id must be a positive integer");
            Id = id;
            ValidateDomain(name, email);
        }

        public User(string name, string email)
        {
            ValidateDomain(name, email);
        }

        private void ValidateDomain(string name, string email)
        {
            DomainExceptionValidation.When(name == null, "Name is required");
            DomainExceptionValidation.When(email == null, "Email is required");
            DomainExceptionValidation.When(name.Length > 200, "Name cannot exceed 200 characters");
            DomainExceptionValidation.When(email.Length > 200, "Email cannot exceed 200 characters");

            Name = name;
            Email = email;
            IsAdmin = false;
        }

        public void SetAdmin(bool admin)
        {
            IsAdmin = admin;
        }

        public void ChangePassword(byte[] passwordHash, byte[] passwordSalt)
        {
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
        }
    }
}
