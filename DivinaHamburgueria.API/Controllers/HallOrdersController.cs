using DivinaHamburgueria.Application.DTOs;
using DivinaHamburgueria.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DivinaHamburgueria.API.Controllers
{

    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class HallOrdersController : Controller
    {

        private readonly IHallOrderService _hallOrderService;

        public HallOrdersController(IHallOrderService hallOrderService)
        {
            _hallOrderService = hallOrderService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HallOrderDTO>>> Get()
        {
            var hallOrder = await _hallOrderService.GetAll();
            return Ok(hallOrder);
        }

        [HttpGet("{id}", Name = "GetHallOrder")]
        public async Task<ActionResult<HallOrderDTO>> Get(int id)
        {
            var hallOrder = await _hallOrderService.GetById(id);
            if (hallOrder == null)
                return NotFound();
            return Ok(hallOrder);
        }

        [HttpPost]
        public async Task<ActionResult<HallOrderDTO>> Post([FromBody] HallOrderDTO hallOrderDTO)
        {
            if (hallOrderDTO == null)
                return BadRequest();
            await _hallOrderService.Add(hallOrderDTO);
            return new CreatedAtRouteResult("GetHallOrder", new { id = hallOrderDTO.Id }, hallOrderDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<HallOrderDTO>> Put(int id, [FromBody] HallOrderDTO hallOrderDTO)
        {
            if (hallOrderDTO == null)
                return BadRequest();
            if (hallOrderDTO.Id != id)
                return BadRequest();
            await _hallOrderService.Update(hallOrderDTO);
            return Ok(hallOrderDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<HallOrderDTO>> Delete(int id)
        {
            var hallOrderDTO = await _hallOrderService.GetById(id);
            if (hallOrderDTO == null)
                return NotFound();
            await _hallOrderService.Remove(id);
            return Ok(hallOrderDTO);
        }

    }
}
