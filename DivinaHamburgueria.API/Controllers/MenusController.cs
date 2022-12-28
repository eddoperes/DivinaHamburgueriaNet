using DivinaHamburgueria.Application.DTOs;
using DivinaHamburgueria.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DivinaHamburgueria.API.Controllers
{

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MenusController : Controller
    {


        private readonly IMenuService _MenuService;

        public MenusController(IMenuService MenuService)
        {
            _MenuService = MenuService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuDTO>>> Get()
        {
            var menuItemsRecipe = await _MenuService.GetAll();
            return Ok(menuItemsRecipe);
        }

        //[HttpGet("GetByName")]
        //public async Task<ActionResult<IEnumerable<MenuDTO>>> GetByName([FromQuery] string? name)
        //{
        //    var menuItemsRecipe = await _MenuService.GetByName(name);
        //    return Ok(menuItemsRecipe);
        //}

        [HttpGet("{id}", Name = "GetMenu")]
        public async Task<ActionResult<MenuDTO>> Get(int id)
        {
            var Menu = await _MenuService.GetById(id);
            if (Menu == null)
                return NotFound();
            return Ok(Menu);
        }

        [HttpPost]
        public async Task<ActionResult<MenuDTO>> Post([FromBody] MenuDTO MenuDTO)
        {
            try
            {
                if (MenuDTO == null)
                    return BadRequest();
                await _MenuService.Add(MenuDTO);
                return new CreatedAtRouteResult("GetMenu", new { id = MenuDTO.Id }, MenuDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MenuDTO>> Put(int id, [FromBody] MenuDTO MenuDTO)
        {
            if (MenuDTO == null)
                return BadRequest();
            if (MenuDTO.Id != id)
                return BadRequest();
            await _MenuService.Update(MenuDTO);
            return Ok(MenuDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<MenuDTO>> Delete(int id)
        {
            var MenuDTO = await _MenuService.GetById(id);
            if (MenuDTO == null)
                return NotFound();
            await _MenuService.Remove(id);
            return Ok(MenuDTO);
        }




    }
}
