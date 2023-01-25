using System;
using System.Collections.Generic;
using System.Text;

namespace DivinaHamburgueria.Application.DTOs
{
    public class UserNoSecretDTO
    {

        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Type { get; set; } = 1;

        public int State { get; set; } = 1;

        public string Email { get; set; } = string.Empty;

    }
}
