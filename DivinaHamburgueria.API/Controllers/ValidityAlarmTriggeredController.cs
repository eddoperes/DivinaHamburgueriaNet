using DivinaHamburgueria.Application.DTOs;
using DivinaHamburgueria.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DivinaHamburgueria.API.Controllers
{

    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
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
