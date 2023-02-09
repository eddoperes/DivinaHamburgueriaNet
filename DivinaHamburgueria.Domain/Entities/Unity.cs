using DivinaHamburgueria.Domain.Validation;
using System;

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


        public static float FindUnitConversionFactor(string unitFrom, string unitTo)
        {

            if (unitFrom.Equals(unitTo))
                return 1f;

            if (unitFrom.ToLower().Equals("gramas") &&
                unitTo.ToLower().Equals("quilos"))
                return 1/1000;

            if (unitFrom.ToLower().Equals("quilos") &&
                unitTo.ToLower().Equals("gramas"))
                return 1000f;

            if (unitFrom.ToLower().Equals("mililitros") &&
                unitTo.ToLower().Equals("litros"))
                return 1/1000;

            if (unitFrom.ToLower().Equals("litros") &&
                unitTo.ToLower().Equals("mililitros"))
                return 1000f;

            throw new Exception("Conversion not especified");

        }

    }

}
