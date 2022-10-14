using DivinaHamburgueria.Domain.Entities;
using DivinaHamburgueria.Domain.Interfaces;
using DivinaHamburgueria.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Infra.Data.Repository
{
    public class UnidadeRepository : IUnidadeRepository
    {

        private ApplicationDbContext _applicationDbContext;

        public UnidadeRepository(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }

        public async Task<IEnumerable<Unidade>> GetAllAsync()
        {
            return await _applicationDbContext.Unidades!.ToListAsync();
        }

        public async Task<Unidade?> GetByIdAsync(int id)
        {
            return await _applicationDbContext.Unidades!.FindAsync(id);
        }

        public async Task<Unidade> CreateAsync(Unidade unidade)
        {
            _applicationDbContext.Add(unidade);
            await _applicationDbContext.SaveChangesAsync();
            return unidade;
        }

        public async Task<Unidade> UpdateAsync(Unidade unidade)
        {
            _applicationDbContext.Update(unidade);
            await _applicationDbContext.SaveChangesAsync();
            return unidade;
        }

        public async Task<Unidade> RemoveAsync(Unidade unidade)
        {
            _applicationDbContext.Remove(unidade);
            await _applicationDbContext.SaveChangesAsync();
            return unidade;
        }

    }
}
