using DivinaHamburgueria.Domain.Entities;
using DivinaHamburgueria.Domain.Interfaces;
using DivinaHamburgueria.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Infra.Data.Repository
{
    public class ProviderRepository : IProviderRepository
    {

        private ApplicationDbContext _applicationDbContext;

        public ProviderRepository(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }

        public async Task<IEnumerable<Provider>> GetAllAsync()
        {
            return await _applicationDbContext.Providers!.ToListAsync();
        }

        public async Task<Provider?> GetByIdAsync(int id)
        {
            return await _applicationDbContext.Providers!.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Provider> CreateAsync(Provider provider)
        {
            _applicationDbContext.Add(provider);
            await _applicationDbContext.SaveChangesAsync();
            return provider;
        }

        public async Task<Provider> UpdateAsync(Provider provider)
        {
            _applicationDbContext.Update(provider);
            await _applicationDbContext.SaveChangesAsync();
            return provider;
        }

        public async Task<Provider> RemoveAsync(Provider provider)
        {
            _applicationDbContext.Remove(provider);
            await _applicationDbContext.SaveChangesAsync();
            return provider;
        }

    }
}
