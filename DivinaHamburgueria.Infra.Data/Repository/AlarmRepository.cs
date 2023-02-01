using DivinaHamburgueria.Domain.Entities;
using DivinaHamburgueria.Domain.Interfaces;
using DivinaHamburgueria.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Infra.Data.Repository
{
    public class AlarmRepository : IAlarmRepository
    {

        private ApplicationDbContext _applicationDbContext;

        public AlarmRepository(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }

        public async Task<IEnumerable<Alarm>> GetAllAsync()
        {
            return await _applicationDbContext.Alarms!.ToListAsync();
        }

        public async Task<IEnumerable<Alarm>> GetByEatableAsync(int? eatableId)
        {
            if (eatableId == null || eatableId == 0)
            {
                return await _applicationDbContext.Alarms!
                                  .ToListAsync();
            }
            else
            {
                return await _applicationDbContext.Alarms!
                                  .Where(m => m.EatableId == eatableId)
                                  .ToListAsync();
            }
        }

        public async Task<Alarm?> GetByIdAsync(int id)
        {
            return await _applicationDbContext.Alarms!
                                              .SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Alarm> CreateAsync(Alarm Alarm)
        {
            _applicationDbContext.Add(Alarm);
            await _applicationDbContext.SaveChangesAsync();
            return Alarm;
        }

        public async Task<Alarm> UpdateAsync(Alarm Alarm)
        {
            _applicationDbContext.Update(Alarm);
            await _applicationDbContext.SaveChangesAsync();
            return Alarm;
        }

        public async Task<Alarm> RemoveAsync(Alarm Alarm)
        {
            _applicationDbContext.Remove(Alarm);
            await _applicationDbContext.SaveChangesAsync();
            return Alarm;
        }

    }
}
