using Bogus;
using DivinaHamburgueria.Domain.Entities;
using DivinaHamburgueria.Domain.Tests.Extensions;

namespace DivinaHamburgueria.Domain.Tests.Builders
{
    public class CustomerBuilder
    {

        private static readonly Faker faker = new Faker();

        private int _id = faker.Random.Int(1, 9999);
        private string _name = faker.Name.FullName();
        private string _cpf = faker.CPF();

        public static CustomerBuilder New()
        {
            return new CustomerBuilder();
        }

        public CustomerBuilder ApplyId(int id)
        {
            _id = id;
            return this;
        }

        public CustomerBuilder ApplyName(string name)
        {
            _name = name;
            return this;
        }

        public CustomerBuilder ApplyCPF(string cpf)
        {
            _cpf = cpf;
            return this;
        }

        public Customer Build()
        {
            return new Customer(_id, _name, _cpf);
        }

    }
}
