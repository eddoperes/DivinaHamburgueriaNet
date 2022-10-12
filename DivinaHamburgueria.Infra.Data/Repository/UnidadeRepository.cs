using DivinaHamburgueria.Domain.Entities;
using DivinaHamburgueria.Domain.Interfaces;
using DivinaHamburgueria.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Infra.Data.Repository
{
    public class UnidadeRepository : IUnidadeRepository
    {

        private ApplicationDbContext _unidadeContext;

        public UnidadeRepository(ApplicationDbContext context)
        {
            _unidadeContext = context;
        }

        public async Task<IEnumerable<Unidade>> GetAllAsync()
        {
            return await _unidadeContext.Unidades.ToListAsync();
        }

        public async Task<Unidade?> GetByIdAsync(int id)
        {
            return await _unidadeContext.Unidades.FindAsync(id);
        }

        public async Task<Unidade> CreateAsync(Unidade unidade)
        {
            _unidadeContext.Add(unidade);
            await _unidadeContext.SaveChangesAsync();
            return unidade;
        }

        public async Task<Unidade> UpdateAsync(Unidade unidade)
        {
            _unidadeContext.Update(unidade);
            await _unidadeContext.SaveChangesAsync();
            return unidade;
        }

        public async Task<Unidade> RemoveAsync(Unidade unidade)
        {
            _unidadeContext.Remove(unidade);
            await _unidadeContext.SaveChangesAsync();
            return unidade;
        }

    }
}
