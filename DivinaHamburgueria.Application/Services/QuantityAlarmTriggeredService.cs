using AutoMapper;
using DivinaHamburgueria.Application.DTOs;
using DivinaHamburgueria.Application.Interfaces;
using DivinaHamburgueria.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Application.Services
{

    public class QuantityAlarmTriggeredService : IQuantityAlarmTriggeredService
    {

        private readonly IQuantityAlarmTriggeredRepository _quantityAlarmTriggeredRepository;
        private readonly IMapper _mapper;

        public QuantityAlarmTriggeredService(IQuantityAlarmTriggeredRepository quantityAlarmTriggeredRepository, IMapper mapper)
        {
            _quantityAlarmTriggeredRepository = quantityAlarmTriggeredRepository ?? throw new ArgumentNullException(nameof(IQuantityAlarmTriggeredRepository));
            _mapper = mapper;
        }

        public async Task<IEnumerable<QuantityAlarmTriggeredDTO>> GetAll()
        {
            var quantityAlarmsTriggered = await _quantityAlarmTriggeredRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<QuantityAlarmTriggeredDTO>>(quantityAlarmsTriggered);
        }

    }
}
