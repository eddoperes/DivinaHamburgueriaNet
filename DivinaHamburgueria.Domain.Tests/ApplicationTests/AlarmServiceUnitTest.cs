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
    public class AlarmServiceUnitTest
    {

        private AlarmDTO _alarmDTO;
        private IMapper _mapper;

        public AlarmServiceUnitTest()
        {

            var faker = new Faker();

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainToDTOMappingProfile());
            });
            _mapper = mockMapper.CreateMapper();

            _alarmDTO = new()
            {
                EatableId = faker.Random.Number(10, 50),
                MinimumQuantity = faker.Random.Number(1, 10),
                UnityId = faker.Random.Number(10, 50),
                ValidityInDays = faker.Random.Number(3, 90),
            };

        }

        // 1 - What test
        // 2 - Complement
        // 3 - Expected result

        [Fact]
        public async void CreateAlarm_ValidDTO_ObjectAddedWithSuccess()
        {

            var alarmRepositoryMock = new Mock<IAlarmRepository>();
            IAlarmService alarmService = new AlarmService(alarmRepositoryMock.Object, _mapper);
            await alarmService.Add(_alarmDTO);

            alarmRepositoryMock.Verify(a => a.CreateAsync(It.Is<Alarm>(a => a.EatableId == _alarmDTO.EatableId &&
                                                                            a.MinimumQuantity == _alarmDTO.MinimumQuantity)));

        }

          [Fact]
        public async void UpdateAlarm_ValidDTO_ObjectAddedWithSuccess()
        {

            _alarmDTO.Id = 1;

            var alarmRepositoryMock = new Mock<IAlarmRepository>();
            IAlarmService alarmService = new AlarmService(alarmRepositoryMock.Object, _mapper);
            await alarmService.Update(_alarmDTO);

            alarmRepositoryMock.Verify(c => c.UpdateAsync(It.IsAny<Alarm>()));

        }

        [Fact]
        public async void RemoveAlarm_ValidDTO_ObjectAddedWithSuccess()
        {

            _alarmDTO.Id = 1;

            Task<Alarm?> GetByIdAsyncFake = Task<Alarm?>.Factory.StartNew(() =>
            {
                var alarm = new Alarm(id: _alarmDTO.Id, 
                                      eatableId: _alarmDTO.EatableId, 
                                      minimumQuantity: _alarmDTO.MinimumQuantity, 
                                      unityId: _alarmDTO.UnityId,
                                      validityInDays: _alarmDTO.ValidityInDays);
                return alarm;
            });

            var alarmRepositoryMock = new Mock<IAlarmRepository>();
            alarmRepositoryMock.Setup(c => c.GetByIdAsync(_alarmDTO.Id)).Returns(GetByIdAsyncFake);

            IAlarmService alarmService = new AlarmService(alarmRepositoryMock.Object, _mapper);
            await alarmService.Remove(_alarmDTO.Id);

            alarmRepositoryMock.Verify(c => c.RemoveAsync(It.Is<Alarm>(c => c.Id == _alarmDTO.Id)));

        }

    }
}
