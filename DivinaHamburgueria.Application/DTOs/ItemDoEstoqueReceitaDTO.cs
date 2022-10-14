using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DivinaHamburgueria.Application.DTOs
{
    public class ItemDoEstoqueReceitaDTO
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é requerido.")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Nome")]
        public string Nome { get; set; } = String.Empty;

        [MaxLength(100)]
        [DisplayName("Marca")]
        public string? Marca { get; set; }

        [DisplayName("Conteudo")]
        public int Conteudo { get; set; }

        [DisplayName("UnidadeId")]
        public int UnidadeId { get; set; }

    }
}
