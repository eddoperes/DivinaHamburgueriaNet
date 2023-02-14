using DivinaHamburgueria.Application.DTOs;
using DivinaHamburgueria.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DivinaHamburgueria.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ValidityAlarmsTriggeredController : Controller
    {

        private readonly IValidityAlarmTriggeredService _validityAlarmTriggeredService;

        public ValidityAlarmsTriggeredController(IValidityAlarmTriggeredService validityAlarmTriggeredService)
        {
            _validityAlarmTriggeredService = validityAlarmTriggeredService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ValidityAlarmTriggeredDTO>>> Get()
        {
            var validityAlarmTriggeredDTOs = await _validityAlarmTriggeredService.GetAll();
            return Ok(validityAlarmTriggeredDTOs);
        }

    }
}
