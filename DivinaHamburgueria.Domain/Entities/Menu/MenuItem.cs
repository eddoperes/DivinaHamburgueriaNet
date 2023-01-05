using DivinaHamburgueria.Domain.Validation;

namespace DivinaHamburgueria.Domain.Entities
{
    public abstract class MenuItem: Entity
    {

        public MenuItem(string name, string description, string photo)
        {
            //called by entity framework    
            ValidateDomain(name, description, photo);
        }

        public MenuItem(int id, string name, string description, string photo)
        {
            DomainExceptionValidation.When(id < 0, "Invalid id. Smaller than zero.");
            this.Id = id;
            //called by mapper  
            ValidateDomain(name, description, photo);
        }

        private void ValidateDomain(string name, string description, string photo)
        {
            DomainExceptionValidation.When(name.Equals(string.Empty), "Invalid name. Name must be informed.");
            DomainExceptionValidation.When(description.Equals(string.Empty), "Invalid description. Description must be informed.");
            DomainExceptionValidation.When(photo.Equals(string.Empty), "Invalid photo. Photo must be informed.");
            this.Name = name;
            this.Description = description;
            this.Photo = photo;
        }

        public string Name { get; private set; } = string.Empty;

        public string Description { get; private set; } = string.Empty;

        public string Photo { get; private set; } = string.Empty;

    }
}
