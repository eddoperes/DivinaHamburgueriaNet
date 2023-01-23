using DivinaHamburgueria.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Application.Interfaces
{
    public interface IUserService
    {

        Task<IEnumerable<UserDTO>> GetAll();

        Task Add(UserDTO userDTO);

    }
}
