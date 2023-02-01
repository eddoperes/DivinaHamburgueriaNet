using DivinaHamburgueria.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Application.Interfaces
{
    public interface IAlarmService
    {

        Task<IEnumerable<AlarmDTO>> GetAll();
        Task<IEnumerable<AlarmDTO>> GetByEatable(int? eatableId);
        Task<AlarmDTO?> GetById(int id);
        Task Add(AlarmDTO AlarmDTO);
        Task Update(AlarmDTO AlarmDTO);
        Task Remove(int id);

    }
}
