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
    public class CardapioRepository : ICardapioRepository
    {

        private ApplicationDbContext _applicationDbContext;

        public CardapioRepository(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }

        public Task<IEnumerable<Cardapio>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Cardapio?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Cardapio> CreateAsync(Cardapio cardapio)
        {
            throw new NotImplementedException();
        }

        public Task<Cardapio> UpdateAsync(Cardapio cardapio)
        {
            throw new NotImplementedException();
        }

        public Task<Cardapio> RemoveAsync(Cardapio cardapio)
        {
            throw new NotImplementedException();
        }

    }
}
