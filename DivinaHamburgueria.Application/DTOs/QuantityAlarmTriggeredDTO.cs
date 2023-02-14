using DivinaHamburgueria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DivinaHamburgueria.Application.DTOs
{
    public class QuantityAlarmTriggeredDTO
    {

        public int Id { get; set; }

        public int EatableId { get; set; }

        public int MinimumQuantity { get; set; }

        public float VerifiedQuantity { get; set; }

        public int UnityId { get; set; }

    }
}
