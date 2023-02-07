using DivinaHamburgueria.Domain.Entities;
using DivinaHamburgueria.Domain.Interfaces;
using DivinaHamburgueria.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DivinaHamburgueria.Infra.Data.Repository
{
    public class ValidityAlarmTriggeredRepository : IValidityAlarmTriggeredRepository
    {

        private ApplicationDbContext _applicationDbContext;

        public ValidityAlarmTriggeredRepository(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }


        public async Task<ValidityAlarmTriggered?>  GetByEatableAsync(int eatableId)
        {
            return await _applicationDbContext.ValidityAlarmsTriggered!
                                              .Where(i => i.EatableId == eatableId)
                                              .FirstOrDefaultAsync();
        }

        public async Task<ValidityAlarmTriggered> CreateAsync(ValidityAlarmTriggered validityAlarmTriggered)
        {
            _applicationDbContext.Add(validityAlarmTriggered);
            await _applicationDbContext.SaveChangesAsync();
            return validityAlarmTriggered;
        }

        public async Task<ValidityAlarmTriggered> UpdateAsync(ValidityAlarmTriggered validityAlarmTriggered)
        {
            _applicationDbContext.Update(validityAlarmTriggered);
            await _applicationDbContext.SaveChangesAsync();
            return validityAlarmTriggered;
        }

        public async Task<ValidityAlarmTriggered> RemoveAsync(ValidityAlarmTriggered validityAlarmTriggered)
        {
            _applicationDbContext.Remove(validityAlarmTriggered);
            await _applicationDbContext.SaveChangesAsync();
            return validityAlarmTriggered;
        }

    }
}
