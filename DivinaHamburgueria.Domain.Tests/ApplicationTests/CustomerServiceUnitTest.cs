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
    public class CustomerServiceUnitTest
    {

        private CustomerDTO _customerDTO;
        private IMapper _mapper;

        public CustomerServiceUnitTest()
        {

            var faker = new Faker();

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainToDTOMappingProfile());
            });
            _mapper = mockMapper.CreateMapper();

            _customerDTO = new()
            {
                Name = faker.Name.FullName(),
                CPF = "00000000272",
                Address = null,
                Phone = null,
            };

        }

        // 1 - What test
        // 2 - Complement
        // 3 - Expected result

        [Fact]
        public void CreateCustomer_ValidDTO_ObjectAddedWithSuccess()
        {

            var customerRepositoryMock = new Mock<ICustomerRepository>();
            ICustomerService customerService = new CustomerService(customerRepositoryMock.Object, _mapper);
            customerService.Add(_customerDTO);

            customerRepositoryMock.Verify(c => c.CreateAsync(It.Is<Customer>(c => c.Name == _customerDTO.Name &&
                                                                                 c.CPF == _customerDTO.CPF)));

        }

        [Fact]
        public void UpdateCustomer_ValidDTO_ObjectAddedWithSuccess()
        {

            var customerRepositoryMock = new Mock<ICustomerRepository>();
            ICustomerService customerService = new CustomerService(customerRepositoryMock.Object, _mapper);
            customerService.Update(_customerDTO);

            customerRepositoryMock.Verify(c => c.UpdateAsync(It.IsAny<Customer>()));

        }

        [Fact]
        public void RemoveCustomer_ValidDTO_ObjectAddedWithSuccess()
        {

            _customerDTO.Id = 1;

            Task<Customer?> GetByIdAsyncFake = Task<Customer?>.Factory.StartNew(() =>
            {
                var customer = new Customer(_customerDTO.Id, _customerDTO.Name, _customerDTO.CPF);
                return customer;
            });

            var customerRepositoryMock = new Mock<ICustomerRepository>();
            customerRepositoryMock.Setup(c => c.GetByIdAsync(_customerDTO.Id)).Returns(GetByIdAsyncFake);

            ICustomerService customerService = new CustomerService(customerRepositoryMock.Object, _mapper);
            customerService.Remove(_customerDTO.Id);

            customerRepositoryMock.Verify(c => c.RemoveAsync(It.Is<Customer>(c => c.Id == _customerDTO.Id)));

        }

    }
}
