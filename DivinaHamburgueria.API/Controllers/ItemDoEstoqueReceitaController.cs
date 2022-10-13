using DivinaHamburgueria.Application.DTOs;
using DivinaHamburgueria.Application.Interfaces;
using DivinaHamburgueria.Domain.Entities;
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
            var itensDoEstoque = await _itemDoEstoqueReceitaService.GetAll();
            return Ok(itensDoEstoque);
        }

        [HttpGet("{id}", Name = "GetItemDoEstoque")]
        public async Task<ActionResult<ItemDoEstoqueReceitaDTO>> Get(int id)
        {
            var itemDoEstoque = await _itemDoEstoqueReceitaService.GetById(id);
            if (itemDoEstoque == null)
                return NotFound();
            return Ok(itemDoEstoque);
        }

        [HttpPost]
        public async Task<ActionResult<ItemDoEstoqueReceitaDTO>> Post([FromBody] ItemDoEstoqueReceitaDTO itemDoEstoque)
        {
            try
            {
                if (itemDoEstoque == null)
                    return BadRequest();
                await _itemDoEstoqueReceitaService.Add(itemDoEstoque);
                return new CreatedAtRouteResult("GetItemDoEstoque", new { id = itemDoEstoque.Id }, itemDoEstoque);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }          
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ItemDoEstoqueReceitaDTO>> Put(int id, [FromBody] ItemDoEstoqueReceitaDTO itemDoEstoque)
        {
            if (itemDoEstoque == null)
                return BadRequest();
            if (itemDoEstoque.Id != id)
                return BadRequest();
            await _itemDoEstoqueReceitaService.Update(itemDoEstoque);
            return Ok(itemDoEstoque);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ItemDoEstoqueReceitaDTO>> Delete(int id)
        {
            var itemDoEstoque = await _itemDoEstoqueReceitaService.GetById(id);
            if (itemDoEstoque == null)
                return NotFound();
            await _itemDoEstoqueReceitaService.Remove(id);
            return Ok(itemDoEstoque);
        }

    }
}
