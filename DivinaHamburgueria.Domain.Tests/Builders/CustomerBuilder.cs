using Bogus;
using DivinaHamburgueria.Domain.Entities;

namespace DivinaHamburgueria.Domain.Tests.Builders
{
    public class CustomerBuilder
    {

        private static int _id;
        private static string _name = "";
        private static string _cpf = "";

        public static CustomerBuilder New()
        {
            var faker = new Faker();
            _id = faker.Random.Int(1,9999);
            _name = faker.Name.FullName();
            _cpf = "11111111111";
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
