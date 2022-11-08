using DivinaHamburgueria.Application.DTOs;
using DivinaHamburgueria.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DivinaHamburgueria.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PurchaseOrdersController : Controller
    {

        private readonly IPurchaseOrderService _purchaseOrder;

        public PurchaseOrdersController(IPurchaseOrderService purchaseOrder)
        {
            _purchaseOrder = purchaseOrder;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchaseOrderDTO>>> Get()
        {
            var purchaseOrder = await _purchaseOrder.GetAll();
            return Ok(purchaseOrder);
        }

        [HttpGet("{id}", Name = "GetPurchaseOrder")]
        public async Task<ActionResult<PurchaseOrderDTO>> Get(int id)
        {
            var purchaseOrder = await _purchaseOrder.GetById(id);
            if (purchaseOrder == null)
                return NotFound();
            return Ok(purchaseOrder);
        }

        [HttpPost]
        public async Task<ActionResult<PurchaseOrderDTO>> Post([FromBody] PurchaseOrderDTO purchaseOrderDTO)
        {
            if (purchaseOrderDTO == null)
                return BadRequest();
            await _purchaseOrder.Add(purchaseOrderDTO);
            return new CreatedAtRouteResult("GetPurchaseOrder", new { id = purchaseOrderDTO.Id }, purchaseOrderDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PurchaseOrderDTO>> Put(int id, [FromBody] PurchaseOrderDTO purchaseOrderDTO)
        {
            if (purchaseOrderDTO == null)
                return BadRequest();
            if (purchaseOrderDTO.Id != id)
                return BadRequest();
            await _purchaseOrder.Update(purchaseOrderDTO);
            return Ok(purchaseOrderDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PurchaseOrderDTO>> Delete(int id)
        {
            var purchaseOrderDTO = await _purchaseOrder.GetById(id);
            if (purchaseOrderDTO == null)
                return NotFound();
            await _purchaseOrder.Remove(id);
            return Ok(purchaseOrderDTO);
        }

    }
}
