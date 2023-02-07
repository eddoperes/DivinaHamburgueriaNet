using DivinaHamburgueria.Domain.Entities;
using DivinaHamburgueria.Domain.Interfaces;
using DivinaHamburgueria.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Infra.Data.Repository
{
    public class QuantityAlarmTriggeredRepository : IQuantityAlarmTriggeredRepository
    {

        private ApplicationDbContext _applicationDbContext;

        public QuantityAlarmTriggeredRepository(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }

        public async Task<QuantityAlarmTriggered?> GetByEatableAsync(int eatableId)
        {
            return await _applicationDbContext.QuantityAlarmsTriggered!
                                              .Where(i => i.EatableId == eatableId)
                                              .FirstOrDefaultAsync();
        }

        public async Task<QuantityAlarmTriggered> CreateAsync(QuantityAlarmTriggered quantityAlarmTriggered)
        {
            _applicationDbContext.Add(quantityAlarmTriggered);
            await _applicationDbContext.SaveChangesAsync();
            return quantityAlarmTriggered;
        }

        public async Task<QuantityAlarmTriggered> UpdateAsync(QuantityAlarmTriggered quantityAlarmTriggered)
        {
            _applicationDbContext.Update(quantityAlarmTriggered);
            await _applicationDbContext.SaveChangesAsync();
            return quantityAlarmTriggered;
        }

        public async Task<QuantityAlarmTriggered> RemoveAsync(QuantityAlarmTriggered quantityAlarmTriggered)
        {
            _applicationDbContext.Remove(quantityAlarmTriggered);
            await _applicationDbContext.SaveChangesAsync();
            return quantityAlarmTriggered;
        }

    }
}
