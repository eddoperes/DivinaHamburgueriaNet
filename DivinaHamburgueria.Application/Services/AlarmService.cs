using AutoMapper;
using DivinaHamburgueria.Application.DTOs;
using DivinaHamburgueria.Application.Interfaces;
using DivinaHamburgueria.Domain.Entities;
using DivinaHamburgueria.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Application.Services
{
    public class AlarmService: IAlarmService
    {

        private readonly IAlarmRepository _AlarmRepository;
        private readonly IMapper _mapper;

        public AlarmService(IAlarmRepository AlarmRepository, IMapper mapper)
        {
            _AlarmRepository = AlarmRepository ?? throw new ArgumentNullException(nameof(IAlarmRepository));
            _mapper = mapper;
        }

        public async Task<IEnumerable<AlarmDTO>> GetAll()
        {
            var Alarms = await _AlarmRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<AlarmDTO>>(Alarms);
        }

        public async Task<IEnumerable<AlarmDTO>> GetByEatable(int? eatableId)
        {
            var Alarms = await _AlarmRepository.GetByEatableAsync(eatableId);
            return _mapper.Map<IEnumerable<AlarmDTO>>(Alarms);
        }

        public async Task<AlarmDTO?> GetById(int id)
        {
            var Alarm = await _AlarmRepository.GetByIdAsync(id);
            return _mapper.Map<AlarmDTO>(Alarm);
        }

        public async Task Add(AlarmDTO AlarmDTO)
        {
            var Alarm = _mapper.Map<Alarm>(AlarmDTO);
            await _AlarmRepository.CreateAsync(Alarm);
        }

        public async Task Update(AlarmDTO AlarmDTO)
        {
            var Alarm = _mapper.Map<Alarm>(AlarmDTO);
            await _AlarmRepository.UpdateAsync(Alarm);
        }

        public async Task Remove(int id)
        {
            var Alarm = await _AlarmRepository.GetByIdAsync(id);
            if (Alarm != null)
                await _AlarmRepository.RemoveAsync(Alarm);

        }

    }
}
