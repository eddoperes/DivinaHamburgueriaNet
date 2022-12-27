using DivinaHamburgueria.Domain.Validation;
using System;

namespace DivinaHamburgueria.Domain.Entities
{
    public class Customer: Entity
    {

        public Customer(string name, string cPF, DateTime? creationDate = null)
        {
            //called by entity framework
            ValidateDomain(name, cPF, creationDate);
        }

        public Customer(int id, string name, string cpf, DateTime? creationDate = null)
        {
            //called by mapper
            DomainExceptionValidation.When(id < 0, "Invalid id. Smaller than zero.");
            this.Id = id;
            ValidateDomain(name, cpf, creationDate);
        }

        private void ValidateDomain(string name, string cpf, DateTime? creationDate = null)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required.");
            DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short, minimum 3 characters.");
            DomainExceptionValidation.When(!IsCPFValid(cpf), "Invalid CPF.");
            this.Name = name;
            this.CPF = cpf;
            this.CreationDate = creationDate;            
        }

        public string Name { get; private set; } = string.Empty;

        public string CPF { get; private set; } = string.Empty;

        public DateTime? CreationDate { get; private set; }

        public bool IsCPFValid(string cpf) 
        {

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf;

            string digito;

            int soma;

            int resto;

            cpf = cpf.Trim();

            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return false;

            tempCpf = cpf.Substring(0, 9);

            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();

            tempCpf = tempCpf + digito;

            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);

        }

    }
}
