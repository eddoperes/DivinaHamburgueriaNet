using DivinaHamburgueria.API.Hypermedia.Filters;
using DivinaHamburgueria.Application.DTOs;
using DivinaHamburgueria.Application.Interfaces;
using DivinaHamburgueria.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DivinaHamburgueria.API.Controllers
{

    [ApiVersion("1")]
    [ApiController]
    [Authorize]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PurchaseOrdersController : Controller
    {

        private readonly IPurchaseOrderService _purchaseOrderService;

        public PurchaseOrdersController(IPurchaseOrderService purchaseOrderService)
        {
            _purchaseOrderService = purchaseOrderService;
        }

        [HttpGet]
        [TypeFilter(typeof(HypermediaFilter))]
        public async Task<ActionResult<IEnumerable<PurchaseOrderDTO>>> Get()
        {
            var purchaseOrder = await _purchaseOrderService.GetAll();
            return Ok(purchaseOrder);
        }

        [HttpGet("GetByProvider")]
        [TypeFilter(typeof(HypermediaFilter))]
        public async Task<ActionResult<IEnumerable<InventoryItemDTO>>> GetByProvider([FromQuery] int? providerid)
        {
            var purchaseOrder = await _purchaseOrderService.GetByProvider(providerid);
            return Ok(purchaseOrder);
        }

        [HttpGet("{id}", Name = "GetPurchaseOrder")]
        [TypeFilter(typeof(HypermediaFilter))]
        public async Task<ActionResult<PurchaseOrderDTO>> Get(int id)
        {
            var purchaseOrder = await _purchaseOrderService.GetById(id);
            if (purchaseOrder == null)
                return NotFound();
            return Ok(purchaseOrder);
        }

        [HttpPost]
        [TypeFilter(typeof(HypermediaFilter))]
        public async Task<ActionResult<PurchaseOrderDTO>> Post([FromBody] PurchaseOrderDTO purchaseOrderDTO)
        {
            try { 
                if (purchaseOrderDTO == null)
                    return BadRequest();
                await _purchaseOrderService.Add(purchaseOrderDTO);
                return new CreatedAtRouteResult("GetPurchaseOrder", new { id = purchaseOrderDTO.Id }, purchaseOrderDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        [TypeFilter(typeof(HypermediaFilter))]
        public async Task<ActionResult<PurchaseOrderDTO>> Put(int id, [FromBody] PurchaseOrderDTO purchaseOrderDTO)
        {
            if (purchaseOrderDTO == null)
                return BadRequest();
            if (purchaseOrderDTO.Id != id)
                return BadRequest();
            await _purchaseOrderService.Update(purchaseOrderDTO);
            return Ok(purchaseOrderDTO);
        }

        [HttpPatch("{id}")]
        [TypeFilter(typeof(HypermediaFilter))]
        public async Task<ActionResult<PurchaseOrderDTO>> ChangeState(int id, [FromBody] PurchaseOrderPatchDTO purchaseOrderPatchDTO)
        {
            if (purchaseOrderPatchDTO == null)
                return BadRequest();
            if (purchaseOrderPatchDTO.Id != id)
                return BadRequest();
            var purchaseOrder = await _purchaseOrderService.Patch(id, purchaseOrderPatchDTO);
            if (purchaseOrder == null)
                return NotFound();
            return Ok(purchaseOrder);
        }

        [HttpDelete("{id}")]
        [TypeFilter(typeof(HypermediaFilter))]
        public async Task<ActionResult<PurchaseOrderDTO>> Delete(int id)
        {
            var purchaseOrderDTO = await _purchaseOrderService.GetById(id);
            if (purchaseOrderDTO == null)
                return NotFound();
            await _purchaseOrderService.Remove(id);
            return Ok(purchaseOrderDTO);
        }

    }
}
