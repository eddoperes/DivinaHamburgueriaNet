using DivinaHamburgueria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Domain.Interfaces
{
    public interface IMenuItemResaleRepository
    {

        Task<IEnumerable<MenuItemResale>> GetAllAsync();
        Task<IEnumerable<MenuItemResale>> GetByNameAsync(string? name);
        Task<MenuItemResale?> GetByIdAsync(int id);
        Task<MenuItemResale> CreateAsync(MenuItemResale menuItemResale);
        Task<MenuItemResale> UpdateAsync(MenuItemResale menuItemResale);
        Task<MenuItemResale> RemoveAsync(MenuItemResale menuItemResale);

    }
}
