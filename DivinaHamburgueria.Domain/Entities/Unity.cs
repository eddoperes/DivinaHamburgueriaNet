using DivinaHamburgueria.Domain.Validation;

namespace DivinaHamburgueria.Domain.Entities
{

    public class Unity: Entity
    {

        public Unity(string name)
        {
            //called by entity framework
            ValidateDomain(name);
        }

        public Unity(int id, string name)
        {
            //called by mapper
            DomainExceptionValidation.When(id < 0, "Invalid id. Smaller than zero.");
            Id = id;
            ValidateDomain(name);
        }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required.");
            DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short, minimum 3 characters.");
            this.Name = name;
        }

        public string Name { get; private set; } = string.Empty;

    }

}
