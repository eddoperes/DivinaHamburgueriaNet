using DivinaHamburgueria.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Application.Interfaces
{
    public interface IMenuItemResaleService
    {

        Task<IEnumerable<MenuItemResaleDTO>> GetAll();
        Task<IEnumerable<MenuItemResaleDTO>> GetByName(string? name);
        Task<MenuItemResaleDTO?> GetById(int id);
        Task Add(MenuItemResaleDTO menuItemResaleDTO);
        Task Update(MenuItemResaleDTO menuItemResaleDTO);
        Task Remove(int id);

    }
}
