using DivinaHamburgueria.Domain.Validation;

namespace DivinaHamburgueria.Domain.Entities
{
    public class ValidityAlarmTriggered : Entity
    {

        public ValidityAlarmTriggered(int eatableId, int validityInDays,
                                      int verifiedInDays)
        {
            //called by entity framework
            ValidateDomain(eatableId, validityInDays,
                                      verifiedInDays);
        }

        public ValidityAlarmTriggered(int id, int eatableId, int validityInDays,
                                      int verifiedInDays)
        {
            //called by mapper
            DomainExceptionValidation.When(id < 0, "Invalid id. Smaller than zero.");
            this.Id = id;
            ValidateDomain(eatableId, validityInDays,
                                      verifiedInDays);
        }

        private void ValidateDomain(int eatableId, int validityInDays,
                                    int verifiedInDays)
        {
            DomainExceptionValidation.When(eatableId <= 0, "Invalid eatable id. Smaller or equal than zero.");
            DomainExceptionValidation.When(validityInDays <= 0, "Invalid validity in days. Smaller or equal than zero.");
            DomainExceptionValidation.When(verifiedInDays <= validityInDays, "Invalid verified in days. Smaller or equal validity in days.");
            this.EatableId = eatableId;
            this.ValidityInDays = validityInDays;
            this.VerifiedInDays = verifiedInDays;
        }

        public int EatableId { get; private set; }

        public Eatable? Eatable { get; private set; }

        public int ValidityInDays { get; private set; }

        public int VerifiedInDays { get; private set; }

    }
}
