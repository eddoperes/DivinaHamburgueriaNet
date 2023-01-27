using System;
using System.Collections.Generic;
using System.Text;
using static DivinaHamburgueria.Domain.Entities.User;

namespace DivinaHamburgueria.Application.DTOs
{
    public class UserDTO
    {

        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Type { get; set; } = 1;

        public int State { get; set; } = 1;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

    }
}
