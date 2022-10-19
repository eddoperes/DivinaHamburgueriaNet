using AutoMapper;
using DivinaHamburgueria.Application.DTOs;
using DivinaHamburgueria.Application.Interfaces;
using DivinaHamburgueria.Domain.Entities;
using DivinaHamburgueria.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Application.Services
{
    public class UnityService : IUnityService
    {

        private IUnityRepository _unityRepository;
        private readonly IMapper _mapper;

        public UnityService(IUnityRepository unityRepository, IMapper mapper) 
        {
            _unityRepository = unityRepository ?? throw new ArgumentNullException(nameof(IUnityRepository));
            _mapper = mapper;
        }

        public async Task<IEnumerable<UnityDTO>> GetAll()
        {
            var unity = await _unityRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UnityDTO>>(unity);
        }

        public async Task<UnityDTO?> GetById(int id)
        {
            var unity = await _unityRepository.GetByIdAsync(id);
            return _mapper.Map<UnityDTO>(unity);
        }

        public async Task Add(UnityDTO unityDTO)
        {
            var unity = _mapper.Map<Unity>(unityDTO);
            await _unityRepository.CreateAsync(unity);
        }

        public async Task Update(UnityDTO unityDTO)
        {
            var unity = _mapper.Map<Unity>(unityDTO);
            await _unityRepository.UpdateAsync(unity);
        }

        public async Task Remove(int id)
        {
            var unity = await _unityRepository.GetByIdAsync(id);
            if (unity != null)
                await _unityRepository.RemoveAsync(unity);
        }

    }
}
