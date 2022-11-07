using DivinaHamburgueria.Domain.Validation;
using System;

namespace DivinaHamburgueria.Domain.Entities
{
    public sealed class Provider: Entity
    {

        public Provider(string Name, string CNPJ, DateTime? CreationDate = null)
        {          
           ValidateDomain(Name, CNPJ, CreationDate);
        }

        public Provider(int Id, string Name, string CNPJ, DateTime? CreationDate = null)
        {
            //called by mapper
            DomainExceptionValidation.When(Id < 0, "Invalid id. Smaller than zero.");
            this.Id = Id;
            ValidateDomain(Name, CNPJ, CreationDate);
        }

        private void ValidateDomain(string Name, string CNPJ, DateTime? CreationDate = null)
        {
            //called by entity framework
            DomainExceptionValidation.When(string.IsNullOrEmpty(Name), "Invalid name. Name is required.");
            DomainExceptionValidation.When(Name.Length < 3, "Invalid name, too short, minimum 3 characters.");            
            this.Name = Name;
            this.CNPJ = CNPJ;
            this.CreationDate = CreationDate; ;
        }

        public string Name { get; private set; } = string.Empty;

        public string CNPJ { get; private set; } = string.Empty;

        public DateTime? CreationDate { get; private set; }

        public void RegisterCreationDate()
        {
            this.CreationDate = DateTime.Now;
        }

    }


}
