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
    public class ItemDoEstoqueRevendaService : IItemDoEstoqueRevendaService
    {

        private IItemDoEstoqueRevendaRepository _itemDoEstoqueRevendaRepository;
        private IComestivelRepository _comestivelRepository;
        private readonly IMapper _mapper;

        public ItemDoEstoqueRevendaService(IItemDoEstoqueRevendaRepository itemDoEstoqueRevendaRepository,
                                           IComestivelRepository comestivelRepository,
                                           IMapper mapper)
        {
            _itemDoEstoqueRevendaRepository = itemDoEstoqueRevendaRepository ?? throw new ArgumentNullException(nameof(ItemDoEstoqueRevenda));
            _comestivelRepository = comestivelRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ItemDoEstoqueRevendaDTO>> GetAll()
        {
            var itensDoEstoqueRevendaEntity = await _itemDoEstoqueRevendaRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ItemDoEstoqueRevendaDTO>>(itensDoEstoqueRevendaEntity);
        }

        public async Task<ItemDoEstoqueRevendaDTO?> GetById(int id)
        {
            var itemDoEstoqueRevendaEntity = await _itemDoEstoqueRevendaRepository.GetByIdAsync(id);
            return _mapper.Map<ItemDoEstoqueRevendaDTO>(itemDoEstoqueRevendaEntity);
        }

        public async Task Add(ItemDoEstoqueRevendaDTO itemDoEstoqueRevendaDTO)
        {
            var itemDoEstoqueRevendaEntity = _mapper.Map<ItemDoEstoqueRevenda>(itemDoEstoqueRevendaDTO);
            var comestivelEntity = await _comestivelRepository.GetByNameAsync(itemDoEstoqueRevendaDTO.Nome);
            if (comestivelEntity != null)
                itemDoEstoqueRevendaEntity.NotificarComestivel(comestivelEntity);
            else
                itemDoEstoqueRevendaEntity.NotificarComestivel(new Comestivel(itemDoEstoqueRevendaDTO.Nome));
            await _itemDoEstoqueRevendaRepository.CreateAsync(itemDoEstoqueRevendaEntity);
        }

        public async Task Update(ItemDoEstoqueRevendaDTO itemDoEstoqueRevendaDTO)
        {
            var itemDoEstoqueRevendaEntity = _mapper.Map<ItemDoEstoqueRevenda>(itemDoEstoqueRevendaDTO);
            var comestivelEntity = await _comestivelRepository.GetByNameAsync(itemDoEstoqueRevendaDTO.Nome);
            if (comestivelEntity != null)
                itemDoEstoqueRevendaEntity.NotificarComestivel(comestivelEntity);
            else
                itemDoEstoqueRevendaEntity.NotificarComestivel(new Comestivel(itemDoEstoqueRevendaDTO.Nome));
            await _itemDoEstoqueRevendaRepository.UpdateAsync(itemDoEstoqueRevendaEntity);
        }

        public async Task Remove(int id)
        {
            var itemDoEstoqueRevendaEntity = await _itemDoEstoqueRevendaRepository.GetByIdAsync(id);
            if (itemDoEstoqueRevendaEntity != null)
                await _itemDoEstoqueRevendaRepository.RemoveAsync(itemDoEstoqueRevendaEntity);
        }

    }
}
