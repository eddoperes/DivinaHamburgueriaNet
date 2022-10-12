using DivinaHamburgueria.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DivinaHamburgueria.Application.DTOs
{
    public class CardapioDTO
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é requerido.")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Nome")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "A descricao é requerida.")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Descricao")]
        public string Descricao { get; set; } = string.Empty;

        [Range(0,1)]
        [DisplayName("Estado")]
        public int Estado { get; set; }

        [DisplayName("ItensDoCardapio")]
        public ICollection<CardapioItemDoCardapioDTO> CardapiosItensDoCardapioDTO{get; set;}

    }
}
