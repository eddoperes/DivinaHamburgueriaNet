using DivinaHamburgueria.Domain.Validation;
using DivinaHamburgueria.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using static DivinaHamburgueria.Domain.Entities.DeliveryOrder;

namespace DivinaHamburgueria.Domain.Entities
{
    public class Alarm: Entity
    {

        public Alarm(int eatableId, int minimumQuantity,
                     int unityId, int validityInDays) 
        {
            //called by entity framework
            ValidateDomain(eatableId, minimumQuantity,
                           unityId, validityInDays);
        }

        public Alarm(int id, int eatableId, int minimumQuantity,
                     int unityId, int validityInDays)
        {
            //called by mapper
            DomainExceptionValidation.When(id < 0, "Invalid id. Smaller than zero.");
            this.Id = id;
            ValidateDomain(eatableId, minimumQuantity,
                           unityId, validityInDays);
        }

        private void ValidateDomain(int eatableId, int minimumQuantity,
                                    int unityId, int validityInDays)
        {
            DomainExceptionValidation.When(eatableId <= 0, "Invalid eatable id. Smaller or equal than zero.");
            DomainExceptionValidation.When(minimumQuantity <= 0, "Invalid minimum quantity. Smaller or equal than zero.");
            DomainExceptionValidation.When(unityId <= 0, "Invalid unity id. Smaller or equal than zero.");
            DomainExceptionValidation.When(validityInDays <= 0, "Invalid validity in days. Smaller or equal than zero.");
            this.EatableId = eatableId;
            this.MinimumQuantity = minimumQuantity;
            this.UnityId = unityId;
            this.ValidityInDays = validityInDays;           
        }

        public int EatableId { get; private set; }

        public Eatable? Eatable { get; private set; }

        public int MinimumQuantity { get; private set; }

        public int UnityId { get; private set; }

        public Unity? Unity { get; private set; }

        public int ValidityInDays { get; private set; }

    }
}
