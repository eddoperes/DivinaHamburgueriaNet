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
    public class ItemDoEstoqueService : IItemDoEstoqueService
    {

        private IItemDoEstoqueRepository _itemDoEstoqueRepository;
        private readonly IMapper _mapper;

        public ItemDoEstoqueService(IItemDoEstoqueRepository itemDoEstoqueRepository, IMapper mapper)
        {
            _itemDoEstoqueRepository = itemDoEstoqueRepository ?? throw new ArgumentNullException(nameof(ItemDoEstoque));
            _mapper = mapper;
        }

        public async Task<IEnumerable<ItemDoEstoqueDTO>> GetAll()
        {
            var itensDoEstoqueEntity = await _itemDoEstoqueRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ItemDoEstoqueDTO>>(itensDoEstoqueEntity);
        }

        public async Task<ItemDoEstoqueDTO?> GetById(int id)
        {
            var itemDoEstoqueEntity = await _itemDoEstoqueRepository.GetByIdAsync(id);
            return _mapper.Map<ItemDoEstoqueDTO>(itemDoEstoqueEntity);
        }

        public async Task Add(ItemDoEstoqueDTO itemDoEstoqueDTO)
        {
            var itemDoEstoqueEntity = _mapper.Map<ItemDoEstoque>(itemDoEstoqueDTO);
            await _itemDoEstoqueRepository.CreateAsync(itemDoEstoqueEntity);
            //var result = await _itemDoEstoqueRepository.CreateAsync(itemDoEstoqueEntity);
            //return result.Id;
        }

        public async Task Update(ItemDoEstoqueDTO itemDoEstoqueDTO)
        {
            var itemDoEstoqueEntity = _mapper.Map<ItemDoEstoque>(itemDoEstoqueDTO);
            await _itemDoEstoqueRepository.UpdateAsync(itemDoEstoqueEntity);
        }

        public async Task Remove(int id)
        {
            var itemDoEstoqueEntity = _itemDoEstoqueRepository.GetByIdAsync(id).Result;
            if (itemDoEstoqueEntity != null)
                await _itemDoEstoqueRepository.RemoveAsync(itemDoEstoqueEntity);
        }

    }
}
