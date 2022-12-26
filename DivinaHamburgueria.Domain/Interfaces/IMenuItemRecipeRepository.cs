using DivinaHamburgueria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Domain.Interfaces
{
    public interface IMenuItemRecipeRepository
    {

        Task<IEnumerable<MenuItemRecipe>> GetAllAsync();
        Task<IEnumerable<MenuItemRecipe>> GetByNameAsync(string? name);
        Task<MenuItemRecipe?> GetByIdAsync(int id);
        Task<MenuItemRecipe> CreateAsync(MenuItemRecipe menuItemRecipe);
        Task<MenuItemRecipe> UpdateAsync(MenuItemRecipe menuItemRecipe);
        Task<MenuItemRecipe> RemoveAsync(MenuItemRecipe menuItemRecipe);

    }
}
