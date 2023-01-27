using DivinaHamburgueria.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Application.Interfaces
{
    public interface IUserService
    {

        Task<IEnumerable<UserNoSecretDTO>> GetAll();

        Task<IEnumerable<UserNoSecretDTO>> GetByName(string? name);

        Task<UserNoSecretDTO?> GetById(int id);

        Task Add(UserDTO userDTO);

        Task<UserNoSecretDTO?> Patch(UserNoSecretDTO userNoSecretDTO);

        Task Remove(int id);

    }
}
