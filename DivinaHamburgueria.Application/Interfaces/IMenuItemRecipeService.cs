using DivinaHamburgueria.Application.DTOs;
using DivinaHamburgueria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Application.Interfaces
{
    public interface IMenuItemRecipeService
    {

        Task<IEnumerable<MenuItemRecipeDTO>> GetAll();
        Task<IEnumerable<MenuItemRecipeDTO>> GetByName(string? name);
        Task<MenuItemRecipeDTO?> GetById(int id);
        Task Add(MenuItemRecipeDTO menuItemRecipeDTO);
        Task Update(MenuItemRecipeDTO menuItemRecipeDTO);
        Task Remove(int id);

    }
}
