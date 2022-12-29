using DivinaHamburgueria.Domain.Entities;
using DivinaHamburgueria.Domain.Interfaces;
using DivinaHamburgueria.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Infra.Data.Repository
{
    public class MenuItemRecipeRepository: IMenuItemRecipeRepository
    {

        private ApplicationDbContext _applicationDbContext;

        public MenuItemRecipeRepository(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }

        public async Task<IEnumerable<MenuItemRecipe>> GetAllAsync()
        {
            return await _applicationDbContext.MenuItemsRecipe!.ToListAsync();
        }

        public async Task<IEnumerable<MenuItemRecipe>> GetByNameAsync(string? name)
        {
            if (name != null)
            {
                return await _applicationDbContext.MenuItemsRecipe!
                                                  .Where(m => m.Name.Contains(name))
                                                  .ToListAsync();
            }
            else
            {
                return await _applicationDbContext.MenuItemsRecipe!.ToListAsync();
            }            
        }

        public async Task<MenuItemRecipe?> GetByIdAsync(int id)
        {
            return await _applicationDbContext.MenuItemsRecipe!.Include(m => m.Ingredients).SingleOrDefaultAsync(m => m.Id == id);
        }

        public async Task<MenuItemRecipe> CreateAsync(MenuItemRecipe menuItemRecipe)
        {
            _applicationDbContext.Add(menuItemRecipe);
            await _applicationDbContext.SaveChangesAsync();
            return menuItemRecipe;
        }

        public async Task<MenuItemRecipe> UpdateAsync(MenuItemRecipe menuItemRecipe)
        {

            var previousMenuItemRecipe = await _applicationDbContext.MenuItemsRecipe!.Include(i => i.Ingredients)
                                                                       .AsNoTracking()
                                                                       .SingleOrDefaultAsync(i => i.Id == menuItemRecipe.Id);
            var currentIngredientsList = menuItemRecipe.Ingredients!.ToList();

            foreach (var previousIngredient in previousMenuItemRecipe!.Ingredients!)
            {
                var currentIngredient = currentIngredientsList.Find(p => p.Id == previousIngredient.Id);
                if (currentIngredient == null)
                    _applicationDbContext.Remove(previousIngredient);
            }

            _applicationDbContext.Update(menuItemRecipe);
            await _applicationDbContext.SaveChangesAsync();
            return menuItemRecipe;
        }

        public async Task<MenuItemRecipe> RemoveAsync(MenuItemRecipe menuItemRecipe)
        {
            _applicationDbContext.Remove(menuItemRecipe);
            await _applicationDbContext.SaveChangesAsync();
            return menuItemRecipe;
        }

    }
}
