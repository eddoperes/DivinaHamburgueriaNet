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
    public class MenuItemResaleService : IMenuItemResaleService
    {

        private readonly IMenuItemResaleRepository _menuItemResaleRepository;
        private readonly IMapper _mapper;

        public MenuItemResaleService(IMenuItemResaleRepository menuItemResaleRepository,
                                     IMapper mapper)
        {
            _menuItemResaleRepository = menuItemResaleRepository ?? throw new ArgumentNullException(nameof(IMenuItemResaleRepository));
            _mapper = mapper;
        }

        public async Task<IEnumerable<MenuItemResaleDTO>> GetAll()
        {
            var menuItemsResale = await _menuItemResaleRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<MenuItemResaleDTO>>(menuItemsResale);
        }

        public async Task<IEnumerable<MenuItemResaleDTO>> GetByName(string? name)
        {
            var menuItemsResale = await _menuItemResaleRepository.GetByNameAsync(name);
            return _mapper.Map<IEnumerable<MenuItemResaleDTO>>(menuItemsResale);
        }

        public async Task<MenuItemResaleDTO?> GetById(int id)
        {
            var menuItemResale = await _menuItemResaleRepository.GetByIdAsync(id);
            return _mapper.Map<MenuItemResaleDTO>(menuItemResale);
        }

        public async Task Add(MenuItemResaleDTO menuItemResaleDTO)
        {
            var menuItemResale = _mapper.Map<MenuItemResale>(menuItemResaleDTO);
            await _menuItemResaleRepository.CreateAsync(menuItemResale);
        }

        public async Task Update(MenuItemResaleDTO menuItemResaleDTO)
        {
            var menuItemResale = _mapper.Map<MenuItemResale>(menuItemResaleDTO);
            await _menuItemResaleRepository.UpdateAsync(menuItemResale);
        }

        public async Task Remove(int id)
        {
            var menuItemResale = await _menuItemResaleRepository.GetByIdAsync(id);
            if (menuItemResale != null)
                await _menuItemResaleRepository.RemoveAsync(menuItemResale);
        }

    }
}
