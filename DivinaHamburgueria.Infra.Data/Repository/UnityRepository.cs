using DivinaHamburgueria.Domain.Entities;
using DivinaHamburgueria.Domain.Interfaces;
using DivinaHamburgueria.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Infra.Data.Repository
{
    public class UnityRepository : IUnityRepository
    {

        private ApplicationDbContext _applicationDbContext;

        public UnityRepository(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }

        public async Task<IEnumerable<Unity>> GetAllAsync()
        {
            return await _applicationDbContext.Units!.ToListAsync();
        }

        public async Task<Unity?> GetByIdAsync(int id)
        {
            return await _applicationDbContext.Units!.FindAsync(id);
        }

        public async Task<Unity> CreateAsync(Unity unidade)
        {
            _applicationDbContext.Add(unidade);
            await _applicationDbContext.SaveChangesAsync();
            return unidade;
        }

        public async Task<Unity> UpdateAsync(Unity unidade)
        {
            _applicationDbContext.Update(unidade);
            await _applicationDbContext.SaveChangesAsync();
            return unidade;
        }

        public async Task<Unity> RemoveAsync(Unity unidade)
        {
            _applicationDbContext.Remove(unidade);
            await _applicationDbContext.SaveChangesAsync();
            return unidade;
        }

    }
}
