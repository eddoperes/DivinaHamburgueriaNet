using DivinaHamburgueria.Domain.Entities;
using DivinaHamburgueria.Domain.Interfaces;
using DivinaHamburgueria.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Infra.Data.Repository
{
    public class MenuRepository : IMenuRepository
    {

        private ApplicationDbContext _applicationDbContext;

        public MenuRepository(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }

        public Task<IEnumerable<Menu>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Menu?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Menu> CreateAsync(Menu cardapio)
        {
            throw new NotImplementedException();
        }

        public Task<Menu> UpdateAsync(Menu cardapio)
        {
            throw new NotImplementedException();
        }

        public Task<Menu> RemoveAsync(Menu cardapio)
        {
            throw new NotImplementedException();
        }

    }
}
