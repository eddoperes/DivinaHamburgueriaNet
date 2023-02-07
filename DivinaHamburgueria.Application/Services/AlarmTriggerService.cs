using DivinaHamburgueria.Application.Interfaces;
using DivinaHamburgueria.Domain.Interfaces;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Application.Services
{
    public class InventorySupervisorService : IInventorySupervisorService
    {

        private readonly IAlarmRepository _alarmRepository;
        private readonly IInventoryRepository _inventoryRepository;
        
        public InventorySupervisorService(IAlarmRepository alarmRepository,
                                          IInventoryRepository inventoryRepository)
        {
            _alarmRepository = alarmRepository;
            _inventoryRepository = inventoryRepository;            
        }

        public async Task Execute()
        {

            var alarms = await _alarmRepository.GetAllAsync();

            foreach (var alarm in alarms)
            {


                //EatableId
                //MinimumQuantity
                //VerifiedQuantity
                //UnityId

                //EatableId
                //ValidityInDays
                //VerifiedInDays


            }

        }
    }
}
