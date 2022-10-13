using DivinaHamburgueria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static DivinaHamburgueria.Domain.Entities.ItemDoEstoque;

namespace DivinaHamburgueria.Application.DTOs
{
    public class ItemDoEstoqueDTO
    {

        public int Id { get; set; }

        [DisplayName("ComestivelId")]
        public int ComestivelId { get; set; }

        [DisplayName("Marca")]
        public string? Marca { get; set; }

        [Range(1, 2)]
        [DisplayName("Tipo")]
        public int Tipo { get;  set; }

        [DisplayName("Conteudo")]
        public int Conteudo { get; set; }

        [DisplayName("UnidadeId")]
        public int UnidadeId { get; set; }

    }
}
