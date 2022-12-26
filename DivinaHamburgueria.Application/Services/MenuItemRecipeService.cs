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
    public class MenuItemRecipeService : IMenuItemRecipeService
    {

        private readonly IMenuItemRecipeRepository _menuItemRecipeRepository;
        private readonly IMapper _mapper;

        public MenuItemRecipeService(IMenuItemRecipeRepository menuItemRecipeRepository,
                                     IMapper mapper)
        {
            _menuItemRecipeRepository = menuItemRecipeRepository ?? throw new ArgumentNullException(nameof(IMenuItemRecipeRepository));
            _mapper = mapper;
        }

        public async Task<IEnumerable<MenuItemRecipeDTO>> GetAll()
        {
            var menuItemsRecipe = await _menuItemRecipeRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<MenuItemRecipeDTO>>(menuItemsRecipe);
        }

        public async Task<IEnumerable<MenuItemRecipeDTO>> GetByName(string? name)
        {
            var menuItemsRecipe = await _menuItemRecipeRepository.GetByNameAsync(name);
            return _mapper.Map<IEnumerable<MenuItemRecipeDTO>>(menuItemsRecipe);
        }

        public async Task<MenuItemRecipeDTO?> GetById(int id)
        {
            var menuItemRecipe = await _menuItemRecipeRepository.GetByIdAsync(id);
            return _mapper.Map<MenuItemRecipeDTO>(menuItemRecipe);
        }

        public async Task Add(MenuItemRecipeDTO menuItemRecipeDTO)
        {
            var menuItemRecipe = _mapper.Map<MenuItemRecipe>(menuItemRecipeDTO);
            await _menuItemRecipeRepository.CreateAsync(menuItemRecipe);
        }

        public async Task Update(MenuItemRecipeDTO menuItemRecipeDTO)
        {
            var menuItemRecipe = _mapper.Map<MenuItemRecipe>(menuItemRecipeDTO);
            await _menuItemRecipeRepository.UpdateAsync(menuItemRecipe);
        }

        public async Task Remove(int id)
        {
            var menuItemRecipe = await _menuItemRecipeRepository.GetByIdAsync(id);
            if (menuItemRecipe != null)
                await _menuItemRecipeRepository.RemoveAsync(menuItemRecipe);
        }

    }
}
