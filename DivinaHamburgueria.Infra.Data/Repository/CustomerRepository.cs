using DivinaHamburgueria.Domain.Entities;
using DivinaHamburgueria.Domain.Interfaces;
using DivinaHamburgueria.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Infra.Data.Repository
{
    public class CustomerRepository : ICustomerRepository
    {

        private ApplicationDbContext _applicationDbContext;

        public CustomerRepository(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _applicationDbContext.Customers!.ToListAsync();
        }

        public async Task<IEnumerable<Customer>> GetByNameAsync(string? name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                return await _applicationDbContext.Customers!
                                                  .Where(m => m.Name.Contains(name))
                                                  .ToListAsync();
            }
            else
            {
                return await _applicationDbContext.Customers!
                                                  .ToListAsync();
            }
        }

        public async Task<Customer?> GetByIdAsync(int id)
        {
            return await _applicationDbContext.Customers!
                                              .SingleOrDefaultAsync(c => c.Id == id);          
        }

        public async Task<Customer> CreateAsync(Customer customer)
        {
            _applicationDbContext.Add(customer);
            await _applicationDbContext.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> UpdateAsync(Customer customer)
        {
            _applicationDbContext.Update(customer);
            await _applicationDbContext.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> RemoveAsync(Customer customer)
        {
            _applicationDbContext.Remove(customer);
            await _applicationDbContext.SaveChangesAsync();
            return customer;
        }

    }
}
