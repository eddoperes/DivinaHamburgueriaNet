using DivinaHamburgueria.Application.DTOs;
using DivinaHamburgueria.Application.Interfaces;
using DivinaHamburgueria.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DivinaHamburgueria.API.Controllers
{

    [ApiVersion("1")]
    [ApiController]
    [Authorize]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class ProvidersController : Controller
    {

        private readonly IProviderService _providerService;

        public ProvidersController(IProviderService providerService)
        {
            _providerService = providerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InventoryItemDTO>>> Get()
        {
            var provider = await _providerService.GetAll();
            return Ok(provider);
        }

        [HttpGet("GetByName")]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetByName([FromQuery] string? name)
        {
            var providerDTOs = await _providerService.GetByName(name);
            return Ok(providerDTOs);
        }

        [HttpGet("{id}", Name = "GetProvider")]
        public async Task<ActionResult<InventoryItemDTO>> Get(int id)
        {
            var provider = await _providerService.GetById(id);
            if (provider == null)
                return NotFound();
            return Ok(provider);
        }

        [HttpPost]
        public async Task<ActionResult<ProviderDTO>> Post([FromBody] ProviderDTO providerDTO)
        {
            if (providerDTO == null)
                return BadRequest();
            await _providerService.Add(providerDTO);
            return new CreatedAtRouteResult("GetProvider", new { id = providerDTO.Id }, providerDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProviderDTO>> Put(int id, [FromBody] ProviderDTO providerDTO)
        {
            if (providerDTO == null)
                return BadRequest();
            if (providerDTO.Id != id)
                return BadRequest();
            await _providerService.Update(providerDTO);
            return Ok(providerDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<InventoryItemDTO>> Delete(int id)
        {
            var providerDTO = await _providerService.GetById(id);
            if (providerDTO == null)
                return NotFound();
            await _providerService.Remove(id);
            return Ok(providerDTO);
        }


    }
}
