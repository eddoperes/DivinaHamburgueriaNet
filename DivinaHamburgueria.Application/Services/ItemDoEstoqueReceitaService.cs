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
    public class ItemDoEstoqueReceitaService : IItemDoEstoqueReceitaService
    {

        private IItemDoEstoqueReceitaRepository _itemDoEstoqueReceitaRepository;
        private readonly IMapper _mapper;

        public ItemDoEstoqueReceitaService(IItemDoEstoqueReceitaRepository itemDoEstoqueReceitaRepository, IMapper mapper)
        {
            _itemDoEstoqueReceitaRepository = itemDoEstoqueReceitaRepository ?? throw new ArgumentNullException(nameof(ItemDoEstoque));
            _mapper = mapper;
        }

        public async Task<IEnumerable<ItemDoEstoqueReceitaDTO>> GetAll()
        {
            var itensDoEstoqueEntity = await _itemDoEstoqueReceitaRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ItemDoEstoqueReceitaDTO>>(itensDoEstoqueEntity);
        }

        public async Task<ItemDoEstoqueReceitaDTO?> GetById(int id)
        {
            var itemDoEstoqueEntity = await _itemDoEstoqueReceitaRepository.GetByIdAsync(id);
            return _mapper.Map<ItemDoEstoqueReceitaDTO>(itemDoEstoqueEntity);
        }

        public async Task Add(ItemDoEstoqueReceitaDTO itemDoEstoqueDTO)
        {
            var itemDoEstoqueEntity = _mapper.Map<ItemDoEstoqueReceita>(itemDoEstoqueDTO);
            await _itemDoEstoqueReceitaRepository.CreateAsync(itemDoEstoqueEntity);
        }

        public async Task Update(ItemDoEstoqueReceitaDTO itemDoEstoqueDTO)
        {
            var itemDoEstoqueEntity = _mapper.Map<ItemDoEstoqueReceita>(itemDoEstoqueDTO);
            await _itemDoEstoqueReceitaRepository.UpdateAsync(itemDoEstoqueEntity);
        }

        public async Task Remove(int id)
        {
            var itemDoEstoqueEntity = _itemDoEstoqueReceitaRepository.GetByIdAsync(id).Result;
            if (itemDoEstoqueEntity != null)
                await _itemDoEstoqueReceitaRepository.RemoveAsync(itemDoEstoqueEntity);
        }

    }
}
