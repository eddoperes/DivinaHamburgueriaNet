using DivinaHamburgueria.Domain.Validation;

namespace DivinaHamburgueria.Domain.Entities
{
    public class Ingredient: Entity
    {

        public Ingredient(int eatableId, int quantity, int unityId) 
        {
            //called by entity framework    
            ValidateDomain(eatableId, quantity, unityId);
        }

        public Ingredient(int id, int eatableId, int quantity, int unityId)
        {
            DomainExceptionValidation.When(id < 0, "Invalid id. Smaller than zero.");
            this.Id = id;
            //called by mapper
            ValidateDomain(eatableId, quantity, unityId);
        }

        private void ValidateDomain(int eatableId, int quantity, int unityId)
        {
            DomainExceptionValidation.When(eatableId <= 0, "Invalid eatable id. Smaller or equal than zero.");
            DomainExceptionValidation.When(quantity <= 0, "Invalid quantity. Smaller or equal than zero.");
            DomainExceptionValidation.When(unityId <= 0, "Invalid unit id. Smaller or equal than zero.");
            this.EatableId = eatableId;
            this.Quantity = quantity;
            this.UnityId =  unityId;
        }

        public int EatableId { get; private set; }

        public Eatable? Eatable { get; private set; }

        public int Quantity { get; private set; } = 0;

        public int UnityId { get; private set; }

        public Unity? Unity { get; private set; }

    }
}
