using DivinaHamburgueria.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Application.Interfaces
{
    public interface ICustomerService
    {

        Task<IEnumerable<CustomerDTO>> GetAll();
        Task<IEnumerable<CustomerDTO>> GetByName(string? name);
        Task<CustomerDTO?> GetById(int id);
        Task Add(CustomerDTO customerDTO);
        Task Update(CustomerDTO customerDTO);
        Task Remove(int id);

    }
}
