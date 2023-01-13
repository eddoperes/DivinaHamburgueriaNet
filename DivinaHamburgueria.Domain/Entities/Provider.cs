using DivinaHamburgueria.Domain.Validation;
using DivinaHamburgueria.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace DivinaHamburgueria.Domain.Entities
{
    public sealed class Provider: Entity
    {

        public Provider(string name, string cNPJ, DateTime? creationDate = null)
        {
            //called by entity framework
            ValidateDomain(name, cNPJ, creationDate);
        }

        public Provider(int id, string name, string cnpj, DateTime? creationDate = null)
        {
            //called by mapper
            DomainExceptionValidation.When(id < 0, "Invalid id. Smaller than zero.");
            this.Id = id;
            ValidateDomain(name, cnpj, creationDate);
        }

        private void ValidateDomain(string name, string cnpj, DateTime? creationDate = null)
        {            
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required.");
            DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short, minimum 3 characters.");
            DomainExceptionValidation.When(!IsCNPJValid(cnpj), "Invalid CNPJ.");
            this.Name = name;
            this.CNPJ = cnpj;
            this.CreationDate = creationDate;
        }

        public string Name { get; private set; } = string.Empty;

        public string CNPJ { get; private set; } = string.Empty;

        public DateTime? CreationDate { get; private set; }

        public void RegisterCreationDate()
        {
            this.CreationDate = DateTime.Now;
        }

        public void Update(string name, string cnpj, DateTime? creationDate = null)
        {
            ValidateDomain(name, cnpj, creationDate);
        }

        public bool IsCNPJValid(string cnpj)
        {

            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            int soma;

            int resto;

            string digito;

            string tempCnpj;

            cnpj = cnpj.Trim();

            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

            if (cnpj.Length != 14)

                return false;

            tempCnpj = cnpj.Substring(0, 12);

            soma = 0;

            for (int i = 0; i < 12; i++)

                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            resto = (soma % 11);

            if (resto < 2)

                resto = 0;

            else

                resto = 11 - resto;

            digito = resto.ToString();

            tempCnpj = tempCnpj + digito;

            soma = 0;

            for (int i = 0; i < 13; i++)

                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);

            if (resto < 2)

                resto = 0;

            else

                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cnpj.EndsWith(digito);

        }

        public Address? Address { get; set; }

        public Phone? Phone { get; set; }

    }


}
