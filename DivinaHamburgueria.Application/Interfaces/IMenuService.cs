using DivinaHamburgueria.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Application.Interfaces
{
    public interface IMenuService
    {

        Task<IEnumerable<MenuDTO>> GetAll();
        Task<IEnumerable<MenuDTO>> GetByName(string? name);
        Task<MenuDTO?> GetById(int id);
        Task Add(MenuDTO menuDTO);
        Task Update(MenuDTO menuDTO);
        Task Remove(int id);

    }
}
