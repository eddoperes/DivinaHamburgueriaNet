using DivinaHamburgueria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text;
using static DivinaHamburgueria.Domain.Entities.CardapioItemDoCardapio;

namespace DivinaHamburgueria.Application.DTOs
{
    public class CardapioItemDoCardapioDTO
    {

        public int Id { get; set; }

        [DisplayName("Preco")]
        public decimal Preco { get; set; }

        [Range(0, 1)]
        [DisplayName("Estado")]
        public int Estado { get; set; }

        [DisplayName("ItemDoCardapioId")]
        public int ItemDoCardapioId { get; set; }

    }
}
