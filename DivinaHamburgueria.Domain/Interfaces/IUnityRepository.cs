using DivinaHamburgueria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Domain.Interfaces
{
    public interface IUnityRepository
    {

        Task<IEnumerable<Unity>> GetAllAsync();
        Task<Unity?> GetByIdAsync(int id);

        Task<Unity> CreateAsync(Unity unity);
        Task<Unity> UpdateAsync(Unity unity);
        Task<Unity> RemoveAsync(Unity unity);

    }
}
