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
            var menuDTOs = await _MenuService.GetAll();
            return Ok(menuDTOs);
        }

        [HttpGet("GetByName")]
        public async Task<ActionResult<IEnumerable<MenuDTO>>> GetByName([FromQuery] string? name)
        {
            var menuDTOs = await _MenuService.GetByName(name);
            return Ok(menuDTOs);
        }

        [HttpGet("{id}", Name = "GetMenu")]
        public async Task<ActionResult<MenuDTO>> Get(int id)
        {
            var menuDTO = await _MenuService.GetById(id);
            if (menuDTO == null)
                return NotFound();
            return Ok(menuDTO);
        }

        [HttpPost]
        public async Task<ActionResult<MenuDTO>> Post([FromBody] MenuDTO menuDTO)
        {
            try
            {
                if (menuDTO == null)
                    return BadRequest();
                await _MenuService.Add(menuDTO);
                return new CreatedAtRouteResult("GetMenu", new { id = menuDTO.Id }, menuDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MenuDTO>> Put(int id, [FromBody] MenuDTO menuDTO)
        {
            try
            {
                if (menuDTO == null)
                    return BadRequest();
                if (menuDTO.Id != id)
                    return BadRequest();
                await _MenuService.Update(menuDTO);
                return Ok(menuDTO);
            }
            catch(Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }            
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<MenuDTO>> Delete(int id)
        {
            var menuDTO = await _MenuService.GetById(id);
            if (menuDTO == null)
                return NotFound();
            await _MenuService.Remove(id);
            return Ok(menuDTO);
        }

    }
}
