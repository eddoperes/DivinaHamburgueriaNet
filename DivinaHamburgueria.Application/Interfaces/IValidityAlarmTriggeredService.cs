using DivinaHamburgueria.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Application.Interfaces
{
    public interface IValidityAlarmTriggeredService
    {

        Task<IEnumerable<ValidityAlarmTriggeredDTO>> GetAll();

    }
}
