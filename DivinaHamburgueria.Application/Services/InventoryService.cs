using AutoMapper;
using DivinaHamburgueria.Application.DTOs;
using DivinaHamburgueria.Application.Interfaces;
using DivinaHamburgueria.Domain.Entities;
using DivinaHamburgueria.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Application.Services
{
    public class InventoryService : IInventoryService
    {

        private readonly IInventoryRepository _inventoryRepository;
        private readonly IMapper _mapper;

        public InventoryService(IInventoryRepository inventoryRepository,
                                IMapper mapper)
        {
            _inventoryRepository = inventoryRepository ?? throw new ArgumentNullException(nameof(IInventoryRepository));
            _mapper = mapper;
        }

        public async Task<IEnumerable<InventoryDTO>> GetAll()
        {
            var inventory = await _inventoryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<InventoryDTO>>(inventory);
        }

        public async Task<InventoryDTO?> GetById(int id)
        {
            var inventory = await _inventoryRepository.GetByIdAsync(id);
            return _mapper.Map<InventoryDTO>(inventory);
        }

        public async Task Add(InventoryDTO inventoryDTO)
        {
            var inventory = _mapper.Map<Inventory>(inventoryDTO);
            await _inventoryRepository.CreateAsync(inventory);
        }

        public async Task Update(InventoryDTO inventoryDTO)
        {
            var inventory = _mapper.Map<Inventory>(inventoryDTO);
            await _inventoryRepository.UpdateAsync(inventory);
        }

        public async Task Remove(int id)
        {
            var inventory = await _inventoryRepository.GetByIdAsync(id);
            if (inventory != null)
                await _inventoryRepository.RemoveAsync(inventory);
        }

    }
}
