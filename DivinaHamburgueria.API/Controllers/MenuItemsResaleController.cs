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
    public class MenuItemsResaleController : Controller
    {

        private readonly IMenuItemResaleService _menuItemResaleService;

        public MenuItemsResaleController(IMenuItemResaleService menuItemResaleService)
        {
            _menuItemResaleService = menuItemResaleService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuItemResaleDTO>>> Get()
        {
            var menuItemsResale = await _menuItemResaleService.GetAll();
            return Ok(menuItemsResale);
        }

        [HttpGet("GetByName")]
        public async Task<ActionResult<IEnumerable<MenuItemResaleDTO>>> GetByName([FromQuery] string? name)
        {
            var menuItemsRecipe = await _menuItemResaleService.GetByName(name);
            return Ok(menuItemsRecipe);
        }

        [HttpGet("{id}", Name = "GetMenuItemResale")]
        public async Task<ActionResult<MenuItemResaleDTO>> Get(int id)
        {
            var menuItemRecipe = await _menuItemResaleService.GetById(id);
            if (menuItemRecipe == null)
                return NotFound();
            return Ok(menuItemRecipe);
        }

        [HttpPost]
        public async Task<ActionResult<MenuItemResaleDTO>> Post([FromBody] MenuItemResaleDTO menuItemResaleDTO)
        {
            try
            {
                if (menuItemResaleDTO == null)
                    return BadRequest();
                await _menuItemResaleService.Add(menuItemResaleDTO);
                return new CreatedAtRouteResult("GetMenuItemResale", new { id = menuItemResaleDTO.Id }, menuItemResaleDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<InventoryItemDTO>> Put(int id, [FromBody] MenuItemResaleDTO menuItemResaleDTO)
        {
            if (menuItemResaleDTO == null)
                return BadRequest();
            if (menuItemResaleDTO.Id != id)
                return BadRequest();
            await _menuItemResaleService.Update(menuItemResaleDTO);
            return Ok(menuItemResaleDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<MenuItemRecipeDTO>> Delete(int id)
        {
            var menuItemRecipeDTO = await _menuItemResaleService.GetById(id);
            if (menuItemRecipeDTO == null)
                return NotFound();
            await _menuItemResaleService.Remove(id);
            return Ok(menuItemRecipeDTO);
        }

    }
}
