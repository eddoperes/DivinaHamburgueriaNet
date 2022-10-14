using DivinaHamburgueria.Application.DTOs;
using DivinaHamburgueria.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DivinaHamburgueria.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ItensDoEstoqueReceitaController : Controller
    {

        private readonly IItemDoEstoqueReceitaService _itemDoEstoqueReceitaService;

        public ItensDoEstoqueReceitaController(IItemDoEstoqueReceitaService itemDoEstoqueReceitaService)
        {
            _itemDoEstoqueReceitaService = itemDoEstoqueReceitaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDoEstoqueReceitaDTO>>> Get()
        {
            var itensDoEstoqueReceita = await _itemDoEstoqueReceitaService.GetAll();
            return Ok(itensDoEstoqueReceita);
        }

        [HttpGet("{id}", Name = "GetItemDoEstoqueReceita")]
        public async Task<ActionResult<ItemDoEstoqueReceitaDTO>> Get(int id)
        {
            var itemDoEstoqueReceita = await _itemDoEstoqueReceitaService.GetById(id);
            if (itemDoEstoqueReceita == null)
                return NotFound();
            return Ok(itemDoEstoqueReceita);
        }

        [HttpPost]
        public async Task<ActionResult<ItemDoEstoqueReceitaDTO>> Post([FromBody] ItemDoEstoqueReceitaDTO itemDoEstoqueReceita)
        {
            try
            {
                if (itemDoEstoqueReceita == null)
                    return BadRequest();
                await _itemDoEstoqueReceitaService.Add(itemDoEstoqueReceita);
                return new CreatedAtRouteResult("GetItemDoEstoqueReceita", new { id = itemDoEstoqueReceita.Id }, itemDoEstoqueReceita);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }          
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ItemDoEstoqueReceitaDTO>> Put(int id, [FromBody] ItemDoEstoqueReceitaDTO itemDoEstoqueReceita)
        {
            if (itemDoEstoqueReceita == null)
                return BadRequest();
            if (itemDoEstoqueReceita.Id != id)
                return BadRequest();
            await _itemDoEstoqueReceitaService.Update(itemDoEstoqueReceita);
            return Ok(itemDoEstoqueReceita);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ItemDoEstoqueReceitaDTO>> Delete(int id)
        {
            var itemDoEstoqueReceita = await _itemDoEstoqueReceitaService.GetById(id);
            if (itemDoEstoqueReceita == null)
                return NotFound();
            await _itemDoEstoqueReceitaService.Remove(id);
            return Ok(itemDoEstoqueReceita);
        }

    }
}
