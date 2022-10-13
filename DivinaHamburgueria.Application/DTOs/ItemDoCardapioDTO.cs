using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text;
using DivinaHamburgueria.Domain.Entities;

namespace DivinaHamburgueria.Application.DTOs
{
    public class ItemDoCardapioDTO
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

        [Required(ErrorMessage = "A fotografia é requerida.")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Fotografia")]
        public string Fotografia { get; set; } = string.Empty;

        [DisplayName("ComestivelId")]
        public int ComestivelId { get; set; }

        [DisplayName("Quantidade")]
        public int Quantidade { get; set; } = 0;

        [DisplayName("UnidadeId")]
        public int UnidadeId { get; set; }

        [DisplayName("ItemDoEstoqueId")]
        public int ItemDoEstoqueId { get; set; }

    }
}
