using DivinaHamburgueria.API.Hypermedia.Filters;
using DivinaHamburgueria.Application.DTOs;
using DivinaHamburgueria.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DivinaHamburgueria.API.Controllers
{

    [ApiVersion("1")]
    [Authorize]
    [ApiController]    
    [Route("api/[controller]/v{version:apiVersion}")]
    public class InventoriesController : Controller
    {

        private readonly IInventoryService _inventoryService;

        public InventoriesController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpGet]
        [TypeFilter(typeof(HypermediaFilter))]
        public async Task<ActionResult<IEnumerable<InventoryItemDTO>>> Get()
        {
            var inventory = await _inventoryService.GetAll();
            return Ok(inventory);
        }

        [HttpGet("GetByEatable")]
        [TypeFilter(typeof(HypermediaFilter))]
        public async Task<ActionResult<IEnumerable<InventoryItemDTO>>> GetByEatable([FromQuery] int? eatableid)
        {
            var inventory = await _inventoryService.GetByEatable(eatableid);
            return Ok(inventory);
        }


        [HttpGet("{id}", Name = "GetInventory")]
        [TypeFilter(typeof(HypermediaFilter))]
        public async Task<ActionResult<InventoryDTO>> Get(int id)
        {
            var inventory = await _inventoryService.GetById(id);
            if (inventory == null)
                return NotFound();
            return Ok(inventory);
        }

        [HttpPost]
        [TypeFilter(typeof(HypermediaFilter))]
        public async Task<ActionResult<InventoryItemDTO>> Post([FromBody] InventoryDTO inventoryDTO)
        {
            try
            {
                if (inventoryDTO == null)
                    return BadRequest();
                await _inventoryService.Add(inventoryDTO);
                return new CreatedAtRouteResult("GetInventory", new { id = inventoryDTO.Id }, inventoryDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        [TypeFilter(typeof(HypermediaFilter))]
        public async Task<ActionResult<InventoryDTO>> Put(int id, [FromBody] InventoryDTO inventoryDTO)
        {
            if (inventoryDTO == null)
                return BadRequest();
            if (inventoryDTO.Id != id)
                return BadRequest();
            await _inventoryService.Update(inventoryDTO);
            return Ok(inventoryDTO);
        }

        [HttpDelete("{id}")]
        [TypeFilter(typeof(HypermediaFilter))]
        public async Task<ActionResult<InventoryDTO>> Delete(int id)
        {
            var inventoryDTO = await _inventoryService.GetById(id);
            if (inventoryDTO == null)
                return NotFound();
            await _inventoryService.Remove(id);
            return Ok(inventoryDTO);
        }

    }
}
