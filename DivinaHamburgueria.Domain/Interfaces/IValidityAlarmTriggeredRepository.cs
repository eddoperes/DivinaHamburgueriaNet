using DivinaHamburgueria.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Domain.Interfaces
{
    public interface IValidityAlarmTriggeredRepository
    {

        Task<ValidityAlarmTriggered?> GetByEatableAsync(int eatableId);

        Task<ValidityAlarmTriggered> CreateAsync(ValidityAlarmTriggered validityAlarmTriggered);
        Task<ValidityAlarmTriggered> UpdateAsync(ValidityAlarmTriggered validityAlarmTriggered);
        Task RemoveBeforeDateAsync(DateTime limitDate);

    }
}
