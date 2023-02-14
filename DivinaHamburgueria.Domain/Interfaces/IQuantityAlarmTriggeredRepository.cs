using DivinaHamburgueria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Domain.Interfaces
{
    public interface IQuantityAlarmTriggeredRepository
    {

        Task<QuantityAlarmTriggered?> GetByEatableAsync(int eatableId);
        Task<IEnumerable<QuantityAlarmTriggered>> GetAllAsync();

        Task<QuantityAlarmTriggered> CreateAsync(QuantityAlarmTriggered quantityAlarmTriggered);
        Task<QuantityAlarmTriggered> UpdateAsync(QuantityAlarmTriggered quantityAlarmTriggered);
        Task RemoveBeforeDateAsync(DateTime limitDate);


    }
}
