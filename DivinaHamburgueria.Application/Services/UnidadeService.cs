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
    public class UnidadeService : IUnidadeService
    {

        private IUnidadeRepository _unidadeRepository;
        private readonly IMapper _mapper;

        public UnidadeService(IUnidadeRepository unidadeRepository, IMapper mapper) 
        {
            _unidadeRepository = unidadeRepository ?? throw new ArgumentNullException(nameof(Unidade));
            _mapper = mapper;
        }

        public async Task<IEnumerable<UnidadeDTO>> GetAll()
        {
            var unidadesEntity = await _unidadeRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UnidadeDTO>>(unidadesEntity);
        }

        public async Task<UnidadeDTO?> GetById(int id)
        {
            var unidadeEntity = await _unidadeRepository.GetByIdAsync(id);
            return _mapper.Map<UnidadeDTO>(unidadeEntity);
        }

        public async Task Add(UnidadeDTO unidadeDTO)
        {
            var unidadeEntity = _mapper.Map<Unidade>(unidadeDTO);
            await _unidadeRepository.CreateAsync(unidadeEntity);
        }

        public async Task Update(UnidadeDTO unidadeDTO)
        {
            var unidadeEntity = _mapper.Map<Unidade>(unidadeDTO);
            await _unidadeRepository.UpdateAsync(unidadeEntity);
        }

        public async Task Remove(int id)
        {
            var unidadeEntity = await _unidadeRepository.GetByIdAsync(id);
            if (unidadeEntity != null)
                await _unidadeRepository.RemoveAsync(unidadeEntity);
        }

    }
}
