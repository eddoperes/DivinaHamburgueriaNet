using DivinaHamburgueria.Domain.Entities;
using DivinaHamburgueria.Domain.Interfaces;
using DivinaHamburgueria.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Infra.Data.Repository
{
    public class EatableRepository : IEatableRepository
    {

        private ApplicationDbContext _applicationDbContext;

        public EatableRepository(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }

        public async Task<IEnumerable<Eatable>> GetAllAsync()
        {
            return await _applicationDbContext.Eatables!
                                              .Join(_applicationDbContext.InventoryItems!, e => e.Id, i => i.EatableId, (e, i) => e)
                                              .OrderBy(e => e.Name)
                                              .ToListAsync();
        }

        public async Task<Eatable?> GetByNameAsync(string name)
        {
            return await _applicationDbContext.Eatables!.SingleOrDefaultAsync(c => c.Name == name);
        }

    }
}
