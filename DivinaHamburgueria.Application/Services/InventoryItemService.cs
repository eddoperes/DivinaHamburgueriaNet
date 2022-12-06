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
    public class InventoryItemService : IInventoryItemService
    {

        private readonly IInventoryItemRepository _inventoryItemRepository;
        private readonly IEatableRepository _eatableRepository;
        private readonly IMapper _mapper;

        public InventoryItemService(IInventoryItemRepository inventoryItemRepository, 
                                    IEatableRepository eatableRepository, 
                                    IMapper mapper)
        {
            _inventoryItemRepository = inventoryItemRepository ?? throw new ArgumentNullException(nameof(IInventoryItemRepository));
            _eatableRepository = eatableRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InventoryItemDTO>> GetAll()
        {
            var inventoryItems = await _inventoryItemRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<InventoryItemDTO>>(inventoryItems);
        }

        public async Task<IEnumerable<EatableDTO>> GetDistinctNames()
        {
            var eatables = await _eatableRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<EatableDTO>>(eatables);
        }

        public async Task<IEnumerable<InventoryItemDTO>> GetByNameAndOrType(string? name, string? type)
        {
            var inventoryItems = await _inventoryItemRepository.GetByNameAndOrTypeAsync(name, type);
            return _mapper.Map<IEnumerable<InventoryItemDTO>>(inventoryItems);
        }

        public async Task<InventoryItemDTO?> GetById(int id)
        {
            var inventoryItem = await _inventoryItemRepository.GetByIdAsync(id);
            return _mapper.Map<InventoryItemDTO>(inventoryItem);
        }

        public async Task Add(InventoryItemDTO itemDoEstoqueReceitaDTO)
        {
            var inventoryItem = _mapper.Map<InventoryItem>(itemDoEstoqueReceitaDTO);
            var eatable = await _eatableRepository.GetByNameAsync(itemDoEstoqueReceitaDTO.Name);
            if (eatable != null)
                inventoryItem.NotificarComestivel(eatable);
            else
                inventoryItem.NotificarComestivel(new Eatable(itemDoEstoqueReceitaDTO.Name));
            await _inventoryItemRepository.CreateAsync(inventoryItem);
        }

        public async Task Update(InventoryItemDTO itemDoEstoqueReceitaDTO)
        {
            var inventoryItem = _mapper.Map<InventoryItem>(itemDoEstoqueReceitaDTO);
            var eatable = await _eatableRepository.GetByNameAsync(itemDoEstoqueReceitaDTO.Name);
            if (eatable != null)
                inventoryItem.NotificarComestivel(eatable);
            else
                inventoryItem.NotificarComestivel(new Eatable(itemDoEstoqueReceitaDTO.Name));
            await _inventoryItemRepository.UpdateAsync(inventoryItem);
        }

        public async Task Remove(int id)
        {
            var inventoryItem = await _inventoryItemRepository.GetByIdAsync(id);
            if (inventoryItem != null)
                await _inventoryItemRepository.RemoveAsync(inventoryItem);
        }

    }
}
