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
    public class MenuItemsRecipeController : Controller
    {

        private readonly IMenuItemRecipeService _menuItemRecipeService;

        public MenuItemsRecipeController(IMenuItemRecipeService menuItemRecipeService)
        {
            _menuItemRecipeService = menuItemRecipeService;
        }

        [HttpGet]
        [TypeFilter(typeof(HypermediaFilter))]
        public async Task<ActionResult<IEnumerable<MenuItemRecipeDTO>>> Get()
        {
            var menuItemsRecipe = await _menuItemRecipeService.GetAll();
            return Ok(menuItemsRecipe);
        }

        [HttpGet("GetByName")]
        [TypeFilter(typeof(HypermediaFilter))]
        public async Task<ActionResult<IEnumerable<MenuItemRecipeDTO>>> GetByName([FromQuery] string? name)
        {
            var menuItemsRecipe = await _menuItemRecipeService.GetByName(name);
            return Ok(menuItemsRecipe);
        }

        [HttpGet("{id}", Name = "GetMenuItemRecipe")]
        [TypeFilter(typeof(HypermediaFilter))]
        public async Task<ActionResult<MenuItemRecipeDTO>> Get(int id)
        {
            var menuItemRecipe = await _menuItemRecipeService.GetById(id);
            if (menuItemRecipe == null)
                return NotFound();
            return Ok(menuItemRecipe);
        }

        [HttpPost]
        [TypeFilter(typeof(HypermediaFilter))]
        public async Task<ActionResult<MenuItemRecipeDTO>> Post([FromBody] MenuItemRecipeDTO menuItemRecipeDTO)
        {
            try
            {
                if (menuItemRecipeDTO == null)
                    return BadRequest();
                await _menuItemRecipeService.Add(menuItemRecipeDTO);
                return new CreatedAtRouteResult("GetMenuItemRecipe", new { id = menuItemRecipeDTO.Id }, menuItemRecipeDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        [TypeFilter(typeof(HypermediaFilter))]
        public async Task<ActionResult<MenuItemRecipeDTO>> Put(int id, [FromBody] MenuItemRecipeDTO menuItemRecipeDTO)
        {
            if (menuItemRecipeDTO == null)
                return BadRequest();
            if (menuItemRecipeDTO.Id != id)
                return BadRequest();
            await _menuItemRecipeService.Update(menuItemRecipeDTO);
            return Ok(menuItemRecipeDTO);
        }

        [HttpDelete("{id}")]
        [TypeFilter(typeof(HypermediaFilter))]
        public async Task<ActionResult<MenuItemRecipeDTO>> Delete(int id)
        {
            var menuItemRecipeDTO = await _menuItemRecipeService.GetById(id);
            if (menuItemRecipeDTO == null)
                return NotFound();
            await _menuItemRecipeService.Remove(id);
            return Ok(menuItemRecipeDTO);
        }

    }

}
