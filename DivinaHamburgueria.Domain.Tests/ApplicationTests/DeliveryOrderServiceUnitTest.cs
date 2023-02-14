using AutoMapper;
using Bogus;
using DivinaHamburgueria.Application.DTOs;
using DivinaHamburgueria.Application.Interfaces;
using DivinaHamburgueria.Application.Mappings;
using DivinaHamburgueria.Application.Services;
using DivinaHamburgueria.Domain.Entities;
using DivinaHamburgueria.Domain.Interfaces;
using Moq;

namespace DivinaHamburgueria.Domain.Tests.ApplicationTests
{
    public class DeliveryOrderServiceUnitTest
    {

        private DeliveryOrderDTO _deliveryOrderDTO;
        private IMapper _mapper;

        public DeliveryOrderServiceUnitTest()
        {

            var faker = new Faker();

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainToDTOMappingProfile());
            });
            _mapper = mockMapper.CreateMapper();

            _deliveryOrderDTO = new()
            {
                UserId = faker.Random.Number(1, 100),
                Observation = faker.Lorem.Text(),
                CustomerId = faker.Random.Number(1, 100),
                Total = faker.Random.Decimal(1, 1000),
                State = 1,
                Payment = 1,
                Supervised = false,
                DeliveryOrderMenuItems = new List<DeliveryOrderMenuItemDTO>(),
            };

        }

        // 1 - What test
        // 2 - Complement
        // 3 - Expected result

        [Fact]
        public void CreateDeliveryOrder_ValidDTO_ObjectAddedWithSuccess()
        {

            var deliveryOrderRepositoryMock = new Mock<IDeliveryOrderRepository>();
            IDeliveryOrderService deliveryOrderService = new DeliveryOrderService(deliveryOrderRepositoryMock.Object, _mapper);
            deliveryOrderService.Add(_deliveryOrderDTO);

            deliveryOrderRepositoryMock.Verify(c => c.CreateAsync(It.Is<DeliveryOrder>(c => c.UserId == _deliveryOrderDTO.UserId &&
                                                                                            c.Observation == _deliveryOrderDTO.Observation)));
        }

        [Fact]
        public void UpdateDeliveryOrder_ValidDTO_ObjectAddedWithSuccess()
        {

            _deliveryOrderDTO.Id = 1;

            var deliveryOrderRepositoryMock = new Mock<IDeliveryOrderRepository>();
            IDeliveryOrderService deliveryOrderService = new DeliveryOrderService(deliveryOrderRepositoryMock.Object, _mapper);
            deliveryOrderService.Update(_deliveryOrderDTO);

            deliveryOrderRepositoryMock.Verify(c => c.UpdateAsync(It.IsAny<DeliveryOrder>()));

        }

        [Fact]
        public void RemoveDeliveryOrder_ValidDTO_ObjectAddedWithSuccess()
        {

            _deliveryOrderDTO.Id = 1;

            Task<DeliveryOrder?> GetByIdAsyncFake = Task<DeliveryOrder?>.Factory.StartNew(() =>
            {
                var deliveryOrder = new DeliveryOrder(id :_deliveryOrderDTO.Id,
                                                      userId: _deliveryOrderDTO.UserId,
                                                      observation: _deliveryOrderDTO.Observation,
                                                      customerId: _deliveryOrderDTO.CustomerId,
                                                      total: _deliveryOrderDTO.Total,
                                                      state: (DeliveryOrder.DeliveryOrderState ) _deliveryOrderDTO.State,
                                                      payment: (DeliveryOrder.DeliveryOrderPayment) _deliveryOrderDTO.Payment,
                                                      supervised: false
                                                     );
                return deliveryOrder;
            });

            var deliveryOrderRepositoryMock = new Mock<IDeliveryOrderRepository>();
            deliveryOrderRepositoryMock.Setup(c => c.GetByIdAsync(_deliveryOrderDTO.Id)).Returns(GetByIdAsyncFake);

            IDeliveryOrderService deliveryOrderService = new DeliveryOrderService(deliveryOrderRepositoryMock.Object, _mapper);
            deliveryOrderService.Remove(_deliveryOrderDTO.Id);

            deliveryOrderRepositoryMock.Verify(c => c.RemoveAsync(It.Is<DeliveryOrder>(d => d.Id == _deliveryOrderDTO.Id)));

        }

    }
}
