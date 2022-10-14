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
    public class ItemDoEstoqueReceitaService : IItemDoEstoqueReceitaService
    {

        private IItemDoEstoqueReceitaRepository _itemDoEstoqueReceitaRepository;
        private IComestivelRepository _comestivelRepository;
        private readonly IMapper _mapper;

        public ItemDoEstoqueReceitaService(IItemDoEstoqueReceitaRepository itemDoEstoqueReceitaRepository, 
                                           IComestivelRepository comestivelRepository, 
                                           IMapper mapper)
        {
            _itemDoEstoqueReceitaRepository = itemDoEstoqueReceitaRepository ?? throw new ArgumentNullException(nameof(ItemDoEstoqueReceita));
            _comestivelRepository = comestivelRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ItemDoEstoqueReceitaDTO>> GetAll()
        {
            var itensDoEstoqueReceitaEntity = await _itemDoEstoqueReceitaRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ItemDoEstoqueReceitaDTO>>(itensDoEstoqueReceitaEntity);
        }

        public async Task<ItemDoEstoqueReceitaDTO?> GetById(int id)
        {
            var itemDoEstoqueReceitaEntity = await _itemDoEstoqueReceitaRepository.GetByIdAsync(id);
            return _mapper.Map<ItemDoEstoqueReceitaDTO>(itemDoEstoqueReceitaEntity);
        }

        public async Task Add(ItemDoEstoqueReceitaDTO itemDoEstoqueReceitaDTO)
        {
            var itemDoEstoqueReceitaEntity = _mapper.Map<ItemDoEstoqueReceita>(itemDoEstoqueReceitaDTO);
            var comestivelEntity = await _comestivelRepository.GetByNameAsync(itemDoEstoqueReceitaDTO.Nome);
            if (comestivelEntity != null)
                itemDoEstoqueReceitaEntity.NotificarComestivel(comestivelEntity);
            else
                itemDoEstoqueReceitaEntity.NotificarComestivel(new Comestivel(itemDoEstoqueReceitaDTO.Nome));
            await _itemDoEstoqueReceitaRepository.CreateAsync(itemDoEstoqueReceitaEntity);
        }

        public async Task Update(ItemDoEstoqueReceitaDTO itemDoEstoqueReceitaDTO)
        {
            var itemDoEstoqueReceitaEntity = _mapper.Map<ItemDoEstoqueReceita>(itemDoEstoqueReceitaDTO);
            var comestivelEntity = await _comestivelRepository.GetByNameAsync(itemDoEstoqueReceitaDTO.Nome);
            if (comestivelEntity != null)
                itemDoEstoqueReceitaEntity.NotificarComestivel(comestivelEntity);
            else
                itemDoEstoqueReceitaEntity.NotificarComestivel(new Comestivel(itemDoEstoqueReceitaDTO.Nome));
            await _itemDoEstoqueReceitaRepository.UpdateAsync(itemDoEstoqueReceitaEntity);
        }

        public async Task Remove(int id)
        {
            var itemDoEstoqueReceitaEntity = await _itemDoEstoqueReceitaRepository.GetByIdAsync(id);
            if (itemDoEstoqueReceitaEntity != null)
                await _itemDoEstoqueReceitaRepository.RemoveAsync(itemDoEstoqueReceitaEntity);
        }

    }
}
