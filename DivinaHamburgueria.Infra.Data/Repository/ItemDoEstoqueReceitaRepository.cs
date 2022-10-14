using DivinaHamburgueria.Domain.Entities;
using DivinaHamburgueria.Domain.Interfaces;
using DivinaHamburgueria.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Infra.Data.Repository
{
    public class ItemDoEstoqueReceitaRepository: IItemDoEstoqueReceitaRepository
    {

        private ApplicationDbContext _applicationDbContext;

        public ItemDoEstoqueReceitaRepository(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }

        public async Task<IEnumerable<ItemDoEstoqueReceita>> GetAllAsync()
        {
            return await _applicationDbContext.ItensDoEstoqueReceita!.Include(i => i.Comestivel)
                                                                     .ToListAsync();
        }

        public async Task<ItemDoEstoqueReceita?> GetByIdAsync(int id)
        {
            return await _applicationDbContext.ItensDoEstoqueReceita!.Include(i => i.Comestivel)
                                                                     .SingleOrDefaultAsync(i => i.Id == id);
        }

        public async Task<ItemDoEstoqueReceita> CreateAsync(ItemDoEstoqueReceita itemDoEstoqueReceita)
        {
            _applicationDbContext.Add(itemDoEstoqueReceita);
            await _applicationDbContext.SaveChangesAsync();
            return itemDoEstoqueReceita;
        }

        public async Task<ItemDoEstoqueReceita> UpdateAsync(ItemDoEstoqueReceita itemDoEstoqueReceita)
        {
            _applicationDbContext.Update(itemDoEstoqueReceita);
            await _applicationDbContext.SaveChangesAsync();
            return itemDoEstoqueReceita;
        }

        public async Task<ItemDoEstoqueReceita> RemoveAsync(ItemDoEstoqueReceita itemDoEstoqueReceita)
        {
            _applicationDbContext.Remove(itemDoEstoqueReceita);
            await _applicationDbContext.SaveChangesAsync();
            return itemDoEstoqueReceita;
        }        

    }
}
