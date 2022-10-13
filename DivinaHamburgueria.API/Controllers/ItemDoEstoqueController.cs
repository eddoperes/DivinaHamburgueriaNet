using DivinaHamburgueria.Application.DTOs;
using DivinaHamburgueria.Application.Interfaces;
using DivinaHamburgueria.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DivinaHamburgueria.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ItensDoEstoqueController : Controller
    {

        private readonly IItemDoEstoqueService _itemDoEstoqueService;

        public ItensDoEstoqueController(IItemDoEstoqueService itemDoEstoqueService)
        {
            _itemDoEstoqueService = itemDoEstoqueService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDoEstoqueDTO>>> Get()
        {
            var itensDoEstoque = await _itemDoEstoqueService.GetAll();
            return Ok(itensDoEstoque);
        }

        [HttpGet("{id}", Name = "GetItemDoEstoque")]
        public async Task<ActionResult<ItemDoEstoqueDTO>> Get(int id)
        {
            var itemDoEstoque = await _itemDoEstoqueService.GetById(id);
            if (itemDoEstoque == null)
                return NotFound();
            return Ok(itemDoEstoque);
        }

        [HttpPost]
        public async Task<ActionResult<ItemDoEstoqueDTO>> Post([FromBody] ItemDoEstoqueDTO itemDoEstoque)
        {
            try
            {
                if (itemDoEstoque == null)
                    return BadRequest();
                await _itemDoEstoqueService.Add(itemDoEstoque);
                return new CreatedAtRouteResult("GetItemDoEstoque", new { id = itemDoEstoque.Id }, itemDoEstoque);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }          
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ItemDoEstoqueDTO>> Put(int id, [FromBody] ItemDoEstoqueDTO itemDoEstoque)
        {
            if (itemDoEstoque == null)
                return BadRequest();
            if (itemDoEstoque.Id != id)
                return BadRequest();
            await _itemDoEstoqueService.Update(itemDoEstoque);
            return Ok(itemDoEstoque);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ItemDoEstoqueDTO>> Delete(int id)
        {
            var itemDoEstoque = await _itemDoEstoqueService.GetById(id);
            if (itemDoEstoque == null)
                return NotFound();
            await _itemDoEstoqueService.Remove(id);
            return Ok(itemDoEstoque);
        }

    }
}
