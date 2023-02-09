using DivinaHamburgueria.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Domain.Interfaces
{
    public interface IQuantityAlarmTriggeredRepository
    {

        Task<QuantityAlarmTriggered?> GetByEatableAsync(int eatableId);

        Task<QuantityAlarmTriggered> CreateAsync(QuantityAlarmTriggered quantityAlarmTriggered);
        Task<QuantityAlarmTriggered> UpdateAsync(QuantityAlarmTriggered quantityAlarmTriggered);
        Task RemoveBeforeDateAsync(DateTime limitDate);


    }
}
