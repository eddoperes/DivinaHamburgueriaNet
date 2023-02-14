using AutoMapper;
using DivinaHamburgueria.Application.DTOs;
using DivinaHamburgueria.Application.Interfaces;
using DivinaHamburgueria.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Application.Services
{
    public class ValidityAlarmTriggeredService : IValidityAlarmTriggeredService
    {

        private readonly IValidityAlarmTriggeredRepository _validityAlarmTriggeredRepository;
        private readonly IMapper _mapper;

        public ValidityAlarmTriggeredService(IValidityAlarmTriggeredRepository validityAlarmTriggeredRepository, IMapper mapper)
        {
            _validityAlarmTriggeredRepository = validityAlarmTriggeredRepository ?? throw new ArgumentNullException(nameof(IValidityAlarmTriggeredRepository));
            _mapper = mapper;
        }

        public async Task<IEnumerable<ValidityAlarmTriggeredDTO>> GetAll()
        {
            var validityAlarmsTriggered = await _validityAlarmTriggeredRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ValidityAlarmTriggeredDTO>>(validityAlarmsTriggered);
        }
    }
}
