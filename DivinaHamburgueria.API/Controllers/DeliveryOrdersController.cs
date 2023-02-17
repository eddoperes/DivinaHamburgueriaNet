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

        [HttpGet("GetByCode")]
        public async Task<ActionResult<IEnumerable<DeliveryOrderDTO>>> GetByCode([FromQuery] int? code)
        {
            var deliveryOrders = await _deliveryOrderService.GetByCode(code);
            return Ok(deliveryOrders);
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
            try
            {
                if (deliveryOrderDTO == null)
                    return BadRequest();
                await _deliveryOrderService.Add(deliveryOrderDTO);
                return new CreatedAtRouteResult("GetDeliveryOrder", new { id = deliveryOrderDTO.Id }, deliveryOrderDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
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

        [HttpPatch("{id}")]
        public async Task<ActionResult<DeliveryOrderDTO>> ChangeState(int id, [FromBody] DeliveryOrderPatchDTO deliveryOrderPatchDTO)
        {
            if (deliveryOrderPatchDTO == null)
                return BadRequest();
            if (deliveryOrderPatchDTO.Id != id)
                return BadRequest();
            var deliveryOrder = await _deliveryOrderService.Patch(id, deliveryOrderPatchDTO);
            if (deliveryOrder == null)
                return NotFound();
            return Ok(deliveryOrder);
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
