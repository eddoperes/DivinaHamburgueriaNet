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
    public class InventoryItemsController : Controller
    {

        private readonly IInventoryItemService _inventoryItemService;

        public InventoryItemsController(IInventoryItemService inventoryItemService)
        {
            _inventoryItemService = inventoryItemService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InventoryItemDTO>>> Get()
        {
            var inventoryItem = await _inventoryItemService.GetAll();
            return Ok(inventoryItem);
        }

        [HttpGet("GetDistinctNames")]
        public async Task<ActionResult<IEnumerable<EatableDTO>>> GetDistinctNames()
        {
            var eatables = await _inventoryItemService.GetDistinctNames();
            return Ok(eatables);
        }

        [HttpGet("GetByNameAndOrType")]
        public async Task<ActionResult<IEnumerable<InventoryItemDTO>>> GetByNameAndOrType([FromQuery] string? name, [FromQuery] string? type)
        {
            var inventoryItem = await _inventoryItemService.GetByNameAndOrType(name, type);
            return Ok(inventoryItem);
        }

        [HttpGet("{id}", Name = "GetInventoryItem")]
        public async Task<ActionResult<InventoryItemDTO>> Get(int id)
        {
            var inventoryItem = await _inventoryItemService.GetById(id);
            if (inventoryItem == null)
                return NotFound();
            return Ok(inventoryItem);
        }

        [HttpPost]
        public async Task<ActionResult<InventoryItemDTO>> Post([FromBody] InventoryItemDTO inventoryItemDTO)
        {
            try
            {
                if (inventoryItemDTO == null)
                    return BadRequest();
                await _inventoryItemService.Add(inventoryItemDTO);
                return new CreatedAtRouteResult("GetInventoryItem", new { id = inventoryItemDTO.Id }, inventoryItemDTO);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }          
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<InventoryItemDTO>> Put(int id, [FromBody] InventoryItemDTO inventoryItemDTO)
        {
            if (inventoryItemDTO == null)
                return BadRequest();
            if (inventoryItemDTO.Id != id)
                return BadRequest();
            await _inventoryItemService.Update(inventoryItemDTO);
            return Ok(inventoryItemDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<InventoryItemDTO>> Delete(int id)
        {
            var inventoryItemDTO = await _inventoryItemService.GetById(id);
            if (inventoryItemDTO == null)
                return NotFound();
            await _inventoryItemService.Remove(id);
            return Ok(inventoryItemDTO);
        }

    }
}
