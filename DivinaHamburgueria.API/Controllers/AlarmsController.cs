using DivinaHamburgueria.Application.DTOs;
using DivinaHamburgueria.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DivinaHamburgueria.API.Controllers
{

    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class AlarmsController : Controller
    {

        private readonly IAlarmService _AlarmService;

        public AlarmsController(IAlarmService AlarmService)
        {
            _AlarmService = AlarmService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlarmDTO>>> Get()
        {
            var AlarmDTOs = await _AlarmService.GetAll();
            return Ok(AlarmDTOs);
        }

        [HttpGet("GetByEatable")]
        public async Task<ActionResult<IEnumerable<AlarmDTO>>> GetByEatable([FromQuery] int? eatableId)
        {
            var AlarmDTOs = await _AlarmService.GetByEatable(eatableId);
            return Ok(AlarmDTOs);
        }

        [HttpGet("{id}", Name = "GetAlarm")]
        public async Task<ActionResult<AlarmDTO>> Get(int id)
        {
            var AlarmDTO = await _AlarmService.GetById(id);
            if (AlarmDTO == null)
                return NotFound();
            return Ok(AlarmDTO);
        }

        [HttpPost]
        public async Task<ActionResult<AlarmDTO>> Post([FromBody] AlarmDTO AlarmDTO)
        {
            try
            {
                if (AlarmDTO == null)
                    return BadRequest();
                await _AlarmService.Add(AlarmDTO);
                return new CreatedAtRouteResult("GetAlarm", new { id = AlarmDTO.Id }, AlarmDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AlarmDTO>> Put(int id, [FromBody] AlarmDTO AlarmDTO)
        {
            try
            {
                if (AlarmDTO == null)
                    return BadRequest();
                if (AlarmDTO.Id != id)
                    return BadRequest();
                await _AlarmService.Update(AlarmDTO);
                return Ok(AlarmDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AlarmDTO>> Delete(int id)
        {
            var AlarmDTO = await _AlarmService.GetById(id);
            if (AlarmDTO == null)
                return NotFound();
            await _AlarmService.Remove(id);
            return Ok(AlarmDTO);
        }


    }
}
