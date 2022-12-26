using System;
using System.Collections.Generic;
using System.Text;

namespace DivinaHamburgueria.Domain.Entities
{
    public class User: Entity
    {

        public enum UserType
        {
            Administrator = 1,
            Assistant = 2,
            Cashier = 3
        }

        public enum State
        {
            Active = 1,
            Inactive = 0
        }

        public string Name { get; private set; } = string.Empty;

        public UserType Type { get; private set; } = UserType.Cashier;

        public string Email { get; private set; } = string.Empty;

        public string Password { get; private set; } = string.Empty;

        public string Token { get; private set; } = string.Empty;

        public DateTime? CreationDate { get; private set; }

        public DateTime? ActivationDate { get; private set; }

        public DateTime? InactivationDate { get; private set; }

    }
}
