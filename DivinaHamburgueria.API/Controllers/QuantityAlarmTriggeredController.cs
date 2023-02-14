using DivinaHamburgueria.Application.DTOs;
using DivinaHamburgueria.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DivinaHamburgueria.API.Controllers
{

    [ApiController]   
    [Route("api/[controller]")]
    public class QuantityAlarmsTriggeredController : Controller
    {

        private readonly IQuantityAlarmTriggeredService _quantityAlarmTriggeredService;

        public QuantityAlarmsTriggeredController(IQuantityAlarmTriggeredService quantityAlarmTriggeredService)
        {
            _quantityAlarmTriggeredService = quantityAlarmTriggeredService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuantityAlarmTriggeredDTO>>> Get()
        {
            var quantityAlarmTriggeredDTOs = await _quantityAlarmTriggeredService.GetAll();
            return Ok(quantityAlarmTriggeredDTOs);
        }

    }



}
