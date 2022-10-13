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
    public class ItemDoEstoqueRepository: IItemDoEstoqueRepository
    {

        private ApplicationDbContext _applicationDbContext;

        public ItemDoEstoqueRepository(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }

        public async Task<IEnumerable<ItemDoEstoque>> GetAllAsync()
        {
            return await _applicationDbContext.ItensDoEstoque!.ToListAsync();
        }

        public async Task<ItemDoEstoque?> GetByIdAsync(int id)
        {
            return await _applicationDbContext.ItensDoEstoque!.FindAsync(id);
        }

        public async Task<ItemDoEstoque> CreateAsync(ItemDoEstoque itemDoEstoque)
        {
            _applicationDbContext.Add(itemDoEstoque);
            await _applicationDbContext.SaveChangesAsync();
            return itemDoEstoque;
        }

        public async Task<ItemDoEstoque> UpdateAsync(ItemDoEstoque itemDoEstoque)
        {
            _applicationDbContext.Update(itemDoEstoque);
            await _applicationDbContext.SaveChangesAsync();
            return itemDoEstoque;
        }

        public async Task<ItemDoEstoque> RemoveAsync(ItemDoEstoque itemDoEstoque)
        {
            _applicationDbContext.Remove(itemDoEstoque);
            await _applicationDbContext.SaveChangesAsync();
            return itemDoEstoque;
        }        

    }
}
