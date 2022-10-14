using DivinaHamburgueria.Domain.Entities;
using DivinaHamburgueria.Domain.Interfaces;
using DivinaHamburgueria.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Infra.Data.Repository
{
    public class ItemDoEstoqueRevendaRepository : IItemDoEstoqueRevendaRepository
    {

        private ApplicationDbContext _applicationDbContext;

        public ItemDoEstoqueRevendaRepository(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }

        public async Task<IEnumerable<ItemDoEstoqueRevenda>> GetAllAsync()
        {
            return await _applicationDbContext.ItensDoEstoqueRevenda!.Include(i => i.Comestivel)
                                                                     .ToListAsync();
        }

        public async Task<ItemDoEstoqueRevenda?> GetByIdAsync(int id)
        {
            return await _applicationDbContext.ItensDoEstoqueRevenda!.Include(i => i.Comestivel)
                                                                     .SingleOrDefaultAsync(i => i.Id == id);
        }

        public async Task<ItemDoEstoqueRevenda> CreateAsync(ItemDoEstoqueRevenda itemDoEstoqueRevenda)
        {
            _applicationDbContext.Add(itemDoEstoqueRevenda);
            await _applicationDbContext.SaveChangesAsync();
            return itemDoEstoqueRevenda;
        }

        public async Task<ItemDoEstoqueRevenda> UpdateAsync(ItemDoEstoqueRevenda itemDoEstoqueRevenda)
        {
            _applicationDbContext.Update(itemDoEstoqueRevenda);
            await _applicationDbContext.SaveChangesAsync();
            return itemDoEstoqueRevenda;
        }

        public async Task<ItemDoEstoqueRevenda> RemoveAsync(ItemDoEstoqueRevenda itemDoEstoqueRevenda)
        {
            _applicationDbContext.Remove(itemDoEstoqueRevenda);
            await _applicationDbContext.SaveChangesAsync();
            return itemDoEstoqueRevenda;
        }

    }
}
