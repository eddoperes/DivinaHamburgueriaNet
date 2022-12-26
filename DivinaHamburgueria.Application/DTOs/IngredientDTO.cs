using DivinaHamburgueria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DivinaHamburgueria.Application.DTOs
{
    public class IngredientDTO
    {

        public int Id { get; set; }

        public int EatableId { get; set; }

        public int Quantity { get; set; }

        public int UnityId { get; set; }

    }
}
