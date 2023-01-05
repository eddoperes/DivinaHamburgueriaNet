using DivinaHamburgueria.Application.DTOs;
using DivinaHamburgueria.Application.Interfaces;
using DivinaHamburgueria.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DivinaHamburgueria.API.Controllers
{

    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class DeliveryOrdersController : Controller
    {

        private readonly IDeliveryOrderService _deliveryOrderService;

        public DeliveryOrdersController(IDeliveryOrderService deliveryOrderService)
        {
            _deliveryOrderService = deliveryOrderService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeliveryOrderDTO>>> Get()
        {
            var deliveryOrder = await _deliveryOrderService.GetAll();
            return Ok(deliveryOrder);
        }

        [HttpGet("{id}", Name = "GetDeliveryOrder")]
        public async Task<ActionResult<HallOrderDTO>> Get(int id)
        {
            var deliveryOrder = await _deliveryOrderService.GetById(id);
            if (deliveryOrder == null)
                return NotFound();
            return Ok(deliveryOrder);
        }

        [HttpPost]
        public async Task<ActionResult<DeliveryOrderDTO>> Post([FromBody] DeliveryOrderDTO deliveryOrderDTO)
        {
            if (deliveryOrderDTO == null)
                return BadRequest();
            await _deliveryOrderService.Add(deliveryOrderDTO);
            return new CreatedAtRouteResult("GetDeliveryOrder", new { id = deliveryOrderDTO.Id }, deliveryOrderDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DeliveryOrderDTO>> Put(int id, [FromBody] DeliveryOrderDTO deliveryOrderDTO)
        {
            if (deliveryOrderDTO == null)
                return BadRequest();
            if (deliveryOrderDTO.Id != id)
                return BadRequest();
            await _deliveryOrderService.Update(deliveryOrderDTO);
            return Ok(deliveryOrderDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DeliveryOrderDTO>> Delete(int id)
        {
            var deliveryOrderDTO = await _deliveryOrderService.GetById(id);
            if (deliveryOrderDTO == null)
                return NotFound();
            await _deliveryOrderService.Remove(id);
            return Ok(deliveryOrderDTO);
        }

    }
}
