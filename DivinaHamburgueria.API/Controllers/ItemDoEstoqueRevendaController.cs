using DivinaHamburgueria.Application.DTOs;
using DivinaHamburgueria.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DivinaHamburgueria.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ItensDoEstoqueRevendaController : Controller
    {

        private readonly IItemDoEstoqueRevendaService _itemDoEstoqueRevendaService;

        public ItensDoEstoqueRevendaController(IItemDoEstoqueRevendaService itemDoEstoqueRevendaService)
        {
            _itemDoEstoqueRevendaService = itemDoEstoqueRevendaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDoEstoqueRevendaDTO>>> Get()
        {
            var itensDoEstoqueRevenda = await _itemDoEstoqueRevendaService.GetAll();
            return Ok(itensDoEstoqueRevenda);
        }

        [HttpGet("{id}", Name = "GetItemDoEstoqueRevenda")]
        public async Task<ActionResult<ItemDoEstoqueRevendaDTO>> Get(int id)
        {
            var itemDoEstoqueRevenda = await _itemDoEstoqueRevendaService.GetById(id);
            if (itemDoEstoqueRevenda == null)
                return NotFound();
            return Ok(itemDoEstoqueRevenda);
        }

        [HttpPost]
        public async Task<ActionResult<ItemDoEstoqueRevendaDTO>> Post([FromBody] ItemDoEstoqueRevendaDTO itemDoEstoqueRevenda)
        {
            try
            {
                if (itemDoEstoqueRevenda == null)
                    return BadRequest();
                await _itemDoEstoqueRevendaService.Add(itemDoEstoqueRevenda);
                return new CreatedAtRouteResult("GetItemDoEstoqueRevenda", new { id = itemDoEstoqueRevenda.Id }, itemDoEstoqueRevenda);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ItemDoEstoqueRevendaDTO>> Put(int id, [FromBody] ItemDoEstoqueRevendaDTO itemDoEstoqueRevenda)
        {
            if (itemDoEstoqueRevenda == null)
                return BadRequest();
            if (itemDoEstoqueRevenda.Id != id)
                return BadRequest();
            await _itemDoEstoqueRevendaService.Update(itemDoEstoqueRevenda);
            return Ok(itemDoEstoqueRevenda);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ItemDoEstoqueRevendaDTO>> Delete(int id)
        {
            var itemDoEstoqueRevenda = await _itemDoEstoqueRevendaService.GetById(id);
            if (itemDoEstoqueRevenda == null)
                return NotFound();
            await _itemDoEstoqueRevendaService.Remove(id);
            return Ok(itemDoEstoqueRevenda);
        }


    }





}
