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
    public class ComestivelRepository : IComestivelRepository
    {

        private ApplicationDbContext _applicationDbContext;

        public ComestivelRepository(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }

        public async Task<Comestivel?> GetByNameAsync(string name)
        {
            return await _applicationDbContext.Comestiveis!.SingleOrDefaultAsync(c => c.Nome == name);
        }
    }
}
