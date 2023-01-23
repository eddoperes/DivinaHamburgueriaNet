using DivinaHamburgueria.Domain.Validation;
using System;

namespace DivinaHamburgueria.Domain.Entities
{
    public class User: Entity
    {

        public User(string name, UserType type, UserState state,
                    string email, string password, string? refreshToken = null,
                    DateTime? refreshTokenExpire = null,
                    DateTime? creationDate = null, DateTime? activationDate = null,
                    DateTime? inactivationDate = null) 
        {
            ValidateDomain(name, type, state,
                           email, password, refreshToken,
                           refreshTokenExpire,
                           creationDate, activationDate,
                           inactivationDate);
        }

        public User(int id, string name, UserType type, UserState state,
                    string email, string password, string? refreshToken = null,
                    DateTime? refreshTokenExpire = null,
                    DateTime? creationDate = null, DateTime? activationDate = null,
                    DateTime? inactivationDate = null)
        {
            DomainExceptionValidation.When(id < 0, "Invalid id. Smaller than zero.");
            this.Id = id;
            ValidateDomain(name, type, state,
                           email, password, refreshToken,
                           refreshTokenExpire,
                           creationDate, activationDate,
                           inactivationDate);
        }

        private void ValidateDomain(string name, UserType type, UserState state,
                                    string email, string password, string? refreshToken = null,
                                    DateTime? refreshTokenExpire = null,
                                    DateTime? creationDate = null, DateTime? activationDate = null,
                                    DateTime? inactivationDate = null)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required.");
            DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short, minimum 3 characters.");
            DomainExceptionValidation.When(type < UserType.Administrator || type > UserType.Cashier, "Invalid type. Out of range 1 to 3.");
            DomainExceptionValidation.When(state < UserState.Inactive || state > UserState.Active, "Invalid state. Out of range 0 to 1.");
            DomainExceptionValidation.When(!email.Contains("@"), "Invalid email. Must have a @ character.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(password), "Invalid password. Password is required.");
            DomainExceptionValidation.When(password.Length < 8, "Invalid password, too short, minimum 8 characters.");
            this.Name = name;
            this.Type = type;
            this.State = state;
            this.Email = email;
            this.Password = password;
            this.RefreshToken = refreshToken;
            this.RefreshTokenExpire = refreshTokenExpire;
            this.CreationDate = creationDate;
            this.ActivationDate = activationDate;
            this.InactivationDate = inactivationDate;
        }

        public enum UserType
        {
            Administrator = 1,
            Assistant = 2,
            Cashier = 3
        }

        public enum UserState
        {
            Active = 1,
            Inactive = 0
        }

        public string Name { get; private set; } = string.Empty;

        public UserType Type { get; private set; } = UserType.Cashier;

        public UserState State { get; private set; } = UserState.Active;

        public string Email { get; private set; } = string.Empty;

        public string Password { get; private set; } = string.Empty;

        public string? RefreshToken { get; private set; }

        public DateTime? RefreshTokenExpire { get; private set; }

        public DateTime? CreationDate { get; private set; }

        public DateTime? ActivationDate { get; private set; }

        public DateTime? InactivationDate { get; private set; }

        public void NotifyRefreshToken(string refreshToken)
        {
            this.RefreshToken= refreshToken;
        }

        public void NotifyRefreshTokenExpire(DateTime refreshTokenExpire)
        {
            this.RefreshTokenExpire = refreshTokenExpire;
        }

        public void NotifyEncryptedPassword(string encryptedPassword)
        {
            this.Password = encryptedPassword;
        }


    }
}
