using DivinaHamburgueria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Domain.Interfaces
{
    public interface IAlarmRepository
    {


        Task<IEnumerable<Alarm>> GetAllAsync();
        Task<IEnumerable<Alarm>> GetByEatableAsync(int? eatableId);
        Task<Alarm?> GetByIdAsync(int id);

        Task<Alarm> CreateAsync(Alarm Alarm);
        Task<Alarm> UpdateAsync(Alarm Alarm);
        Task<Alarm> RemoveAsync(Alarm Alarm);


    }
}
