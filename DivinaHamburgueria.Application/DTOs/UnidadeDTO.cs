using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DivinaHamburgueria.Application.DTOs
{
    public class UnidadeDTO
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é requerido.")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Nome { get; set; } = String.Empty;

    }
}
