using AutoMapper;
using DivinaHamburgueria.Application.DTOs;
using DivinaHamburgueria.Application.Interfaces;
using DivinaHamburgueria.Domain.Entities;
using DivinaHamburgueria.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Application.Services
{
    public class ProviderService : IProviderService
    {

        private readonly IProviderRepository _providerRepository;
        private readonly IMapper _mapper;

        public ProviderService(IProviderRepository providerRepository,
                               IMapper mapper)
        {
            _providerRepository = providerRepository ?? throw new ArgumentNullException(nameof(IProviderRepository));
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProviderDTO>> GetAll()
        {
            var providers = await _providerRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProviderDTO>>(providers);
        }

        public async Task<IEnumerable<ProviderDTO>> GetByName(string? name)
        {
            var providers = await _providerRepository.GetByNameAsync(name);
            return _mapper.Map<IEnumerable<ProviderDTO>>(providers);
        }

        public async Task<ProviderDTO?> GetById(int id)
        {
            var provider = await _providerRepository.GetByIdAsync(id);
            return _mapper.Map<ProviderDTO>(provider);
        }

        public async Task Add(ProviderDTO providerDTO)
        {
            var provider = _mapper.Map<Provider>(providerDTO);
            provider.RegisterCreationDate();
            await _providerRepository.CreateAsync(provider);
        }

        public async Task Update(ProviderDTO providerDTO)
        {
            var provider = _mapper.Map<Provider>(providerDTO);
            await _providerRepository.UpdateAsync(provider);
        }

        public async Task Remove(int id)
        {
            var provider = await _providerRepository.GetByIdAsync(id);
            if (provider != null)
                await _providerRepository.RemoveAsync(provider);
        }

    }
}
