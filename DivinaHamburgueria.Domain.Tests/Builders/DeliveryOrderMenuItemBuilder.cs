using Bogus;
using DivinaHamburgueria.Domain.Entities;

namespace DivinaHamburgueria.Domain.Tests.Builders
{
    public class DeliveryOrderMenuItemBuilder
    {

        private static readonly Faker faker = new Faker();

        private int _id = faker.Random.Int(1, 9999);
        private int _menuItemId = faker.Random.Int(1, 9999);
        private decimal _price = Math.Round(faker.Random.Decimal(1, 100), 2);

        public static DeliveryOrderMenuItemBuilder New()
        {
            return new DeliveryOrderMenuItemBuilder();
        }

        public DeliveryOrderMenuItemBuilder ApplyId(int id)
        {
            _id = id;
            return this;
        }

        public DeliveryOrderMenuItemBuilder ApplyMenuItemId(int menuItemId)
        {
            _menuItemId = menuItemId;
            return this;
        }

        public DeliveryOrderMenuItemBuilder ApplyPrice(decimal price)
        {
            _price = price;
            return this;
        }

        public DeliveryOrderMenuItem Build()
        {
            return new DeliveryOrderMenuItem(_id, _menuItemId, _price);
        }

    }
}
