using DivinaHamburgueria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DivinaHamburgueria.Application.DTOs
{
    public class ValidityAlarmTriggeredDTO
    {

        public int Id { get; set; }

        public int EatableId { get; set; }

        public int ValidityInDays { get; set; }

        public float PossiblySpoiled { get; set; }

        public int UnityId { get; set; }

    }
}
