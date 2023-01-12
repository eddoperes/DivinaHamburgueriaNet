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
    public class MenuService : IMenuService
    {

        private readonly IMenuRepository _menuRepository;
        private readonly IMapper _mapper;

        public MenuService(IMenuRepository menuRepository, IMapper mapper)
        {
            _menuRepository = menuRepository ?? throw new ArgumentNullException(nameof(IMenuRepository));
            _mapper = mapper;
        }

        public async Task<IEnumerable<MenuDTO>> GetAll()
        {
            var menus = await _menuRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<MenuDTO>>(menus);
        }

        public async Task<IEnumerable<MenuDTO>> GetByName(string? name)
        {
            var menus = await _menuRepository.GetByNameAsync(name);
            return _mapper.Map<IEnumerable<MenuDTO>>(menus);
        }

        public async Task<MenuDTO?> GetById(int id)
        {
            var cardapioEntity = await _menuRepository.GetByIdAsync(id);
            return _mapper.Map<MenuDTO>(cardapioEntity);
        }

        public async Task Add(MenuDTO CardapioDTO)
        {
            var cardapioEntity = _mapper.Map<Menu>(CardapioDTO);
            await _menuRepository.CreateAsync(cardapioEntity);
        }

        public async Task Update(MenuDTO CardapioDTO)
        {
            var cardapioEntity = _mapper.Map<Menu>(CardapioDTO);
            await _menuRepository.UpdateAsync(cardapioEntity);
        }

        public async Task Remove(int id)
        {
            var cardapioEntity = await _menuRepository.GetByIdAsync(id);
            if (cardapioEntity != null)
                await _menuRepository.RemoveAsync(cardapioEntity);
        }

    }
}
