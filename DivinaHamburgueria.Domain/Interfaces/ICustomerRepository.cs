using DivinaHamburgueria.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Domain.Interfaces
{
    public interface ICustomerRepository
    {

        Task<IEnumerable<Customer>> GetAllAsync();
        Task<IEnumerable<Customer>> GetByNameAsync(string? name);
        Task<Customer?> GetByIdAsync(int id);

        Task<Customer> CreateAsync(Customer customer);
        Task<Customer> UpdateAsync(Customer customer);
        Task<Customer> RemoveAsync(Customer customer);

    }
}
