using DivinaHamburgueria.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Application.Interfaces
{
    public interface IMenuService
    {

        Task<IEnumerable<MenuDTO>> GetAll();
        Task<MenuDTO?> GetById(int id);
        Task Add(MenuDTO menuDTO);
        Task Update(MenuDTO menuDTO);
        Task Remove(int id);

    }
}
