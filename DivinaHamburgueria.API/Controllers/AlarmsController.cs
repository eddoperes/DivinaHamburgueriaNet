using DivinaHamburgueria.API.Hypermedia.Filters;
using DivinaHamburgueria.Application.DTOs;
using DivinaHamburgueria.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DivinaHamburgueria.API.Controllers
{

    [ApiVersion("1")]
    [ApiController]
    [Authorize]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class AlarmsController : Controller
    {

        private readonly IAlarmService _AlarmService;

        public AlarmsController(IAlarmService AlarmService)
        {
            _AlarmService = AlarmService;
        }

        [HttpGet]
        [TypeFilter(typeof(HypermediaFilter))]
        public async Task<ActionResult<IEnumerable<AlarmDTO>>> Get()
        {
            var AlarmDTOs = await _AlarmService.GetAll();
            return Ok(AlarmDTOs);
        }

        [HttpGet("GetByEatable")]
        [TypeFilter(typeof(HypermediaFilter))]
        public async Task<ActionResult<IEnumerable<AlarmDTO>>> GetByEatable([FromQuery] int? eatableId)
        {
            var AlarmDTOs = await _AlarmService.GetByEatable(eatableId);
            return Ok(AlarmDTOs);
        }

        [HttpGet("{id}", Name = "GetAlarm")]
        [TypeFilter(typeof(HypermediaFilter))]
        public async Task<ActionResult<AlarmDTO>> Get(int id)
        {
            var AlarmDTO = await _AlarmService.GetById(id);
            if (AlarmDTO == null)
                return NotFound();
            return Ok(AlarmDTO);
        }

        [HttpPost]
        [TypeFilter(typeof(HypermediaFilter))]
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
        [TypeFilter(typeof(HypermediaFilter))]
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
        [TypeFilter(typeof(HypermediaFilter))]
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
