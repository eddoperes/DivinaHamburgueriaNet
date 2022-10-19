using DivinaHamburgueria.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Application.Interfaces
{
    public interface IUnityService
    {

        Task<IEnumerable<UnityDTO>> GetAll();
        Task<UnityDTO?> GetById(int id);
        Task Add(UnityDTO unityDTO);
        Task Update(UnityDTO unityDTO);
        Task Remove(int id);

    }
}
