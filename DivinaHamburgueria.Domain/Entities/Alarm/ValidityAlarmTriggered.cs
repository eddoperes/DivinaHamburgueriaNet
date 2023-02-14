using DivinaHamburgueria.Domain.Validation;
using System;
using System.Security.Claims;

namespace DivinaHamburgueria.Domain.Entities
{
    public class ValidityAlarmTriggered : Entity
    {

        public ValidityAlarmTriggered(int eatableId, int validityInDays,
                                      float possiblySpoiled, int unityId, DateTime updated)
        {
            //called by entity framework
            ValidateDomain(eatableId, validityInDays,
                                      possiblySpoiled, unityId, updated);
        }

        public ValidityAlarmTriggered(int id, int eatableId, int validityInDays,
                                      float possiblySpoiled, int unityId, DateTime updated)
        {
            //called by mapper
            DomainExceptionValidation.When(id < 0, "Invalid id. Smaller than zero.");
            this.Id = id;
            ValidateDomain(eatableId, validityInDays,
                                      possiblySpoiled, unityId, updated);
        }

        private void ValidateDomain(int eatableId, int validityInDays,
                                    float possiblySpoiled, int unityId, DateTime updated)
        {
            DomainExceptionValidation.When(eatableId <= 0, "Invalid eatable id. Smaller or equal than zero.");
            DomainExceptionValidation.When(validityInDays <= 0, "Invalid validity in days. Smaller or equal than zero.");
            DomainExceptionValidation.When(possiblySpoiled <= 0, "Invalid possibly spoiled. Smaller or equal than zero.");
            this.EatableId = eatableId;
            this.ValidityInDays = validityInDays;
            this.PossiblySpoiled = possiblySpoiled;
            this.UnityId= unityId;
            this.Updated = updated;
        }

        public int EatableId { get; private set; }

        public Eatable? Eatable { get; private set; }

        public int ValidityInDays { get; private set; }

        public float PossiblySpoiled { get; private set; }

        public int UnityId { get; private set; }

        public Unity? Unity { get; private set; }

        public DateTime Updated { get; private set; }

        public void Update(int validityInDays,
                           float possiblySpoiled,
                           int unityId,
                           DateTime updatedDate)
        {
            this.ValidityInDays = validityInDays;
            this.PossiblySpoiled = possiblySpoiled; 
            this.UnityId = unityId;
            this.Updated = updatedDate;
        }

    }
}
