using DivinaHamburgueria.Domain.Validation;
using System;

namespace DivinaHamburgueria.Domain.Entities
{
    public class QuantityAlarmTriggered : Entity
    {

        public QuantityAlarmTriggered(int eatableId, int minimumQuantity,
                                      float verifiedQuantity, int unityId,
                                      DateTime updated)
        {
            //called by entity framework
            ValidateDomain(eatableId, minimumQuantity,
                           verifiedQuantity, unityId,
                           updated);
        }

        public QuantityAlarmTriggered(int id, int eatableId, int minimumQuantity,
                                      float verifiedQuantity, int unityId,
                                      DateTime updated)
        {
            //called by mapper
            DomainExceptionValidation.When(id < 0, "Invalid id. Smaller than zero.");
            this.Id = id;
            ValidateDomain(eatableId, minimumQuantity,
                           verifiedQuantity, unityId,
                           updated);
        }

        private void ValidateDomain(int eatableId, int minimumQuantity,
                                    float verifiedQuantity, int unityId,
                                    DateTime updated)
        {
            DomainExceptionValidation.When(eatableId <= 0, "Invalid eatable id. Smaller or equal than zero.");
            DomainExceptionValidation.When(minimumQuantity <= 0, "Invalid minimum quantity. Smaller or equal than zero.");
            DomainExceptionValidation.When(verifiedQuantity > minimumQuantity, "Invalid verified quantity. Bigger than minimum quantity.");
            DomainExceptionValidation.When(unityId <= 0, "Invalid unity id. Smaller or equal than zero.");
            this.EatableId = eatableId;
            this.MinimumQuantity = minimumQuantity;
            this.VerifiedQuantity = verifiedQuantity;
            this.UnityId = unityId;
            this.Updated = updated;
        }

        public int EatableId { get; private set; }

        public Eatable? Eatable { get; private set; }

        public int MinimumQuantity { get; private set; }

        public float VerifiedQuantity { get; private set; }

        public int UnityId { get; private set; }

        public Unity? Unity { get; private set; }

        public DateTime Updated { get; private set; }

        public void Update(int minimumQuantity,
                           float verifiedQuantity,
                           int unityId,
                           DateTime updated)
        {
            this.MinimumQuantity = minimumQuantity;
            this.VerifiedQuantity = verifiedQuantity;
            this.UnityId = unityId;
            this.Updated =  updated;
        }

    }
}
