using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text;
using DivinaHamburgueria.Domain.Entities;

namespace DivinaHamburgueria.Application.DTOs
{
    public class MenuItemDTO
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "The name is required.")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "The description is required.")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Description")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "A photo is required.")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Photo")]
        public string Photo { get; set; } = string.Empty;

        [DisplayName("EatableId")]
        public int EatableId { get; set; }

        [DisplayName("Quantity")]
        public int Quantity{ get; set; } = 0;

        [DisplayName("UnityId")]
        public int UnityId { get; set; }

        [DisplayName("InventoryItemId")]
        public int InventoryItemId { get; set; }

    }
}
