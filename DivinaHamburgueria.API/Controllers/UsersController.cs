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
    public class UsersController : Controller
    {

        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserNoSecretDTO>>> Get()
        {
            var userDTOs = await _userService.GetAll();          
            return Ok(userDTOs);
        }

        [HttpGet("GetByName")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetByName([FromQuery] string? name)
        {
            var userDTOs = await _userService.GetByName(name);
            return Ok(userDTOs);
        }

        [HttpGet("{id}", Name = "GetUser")]
        public async Task<ActionResult<UserDTO>> Get(int id)
        {
            var userDTO = await _userService.GetById(id);            
            if (userDTO == null)
                return NotFound();
            return Ok(userDTO);
        }

        [HttpPost]
        public async Task<ActionResult<UserNoSecretDTO>> Post([FromBody] UserDTO userDTO)
        {
            try
            {
                if (userDTO == null)
                    return BadRequest();
                await _userService.Add(userDTO);
                return new CreatedAtRouteResult("GetUser", new { id = userDTO.Id }, userDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<UserNoSecretDTO>> Patch(int id, [FromBody] UserNoSecretDTO userNoSecretDTO)
        {
            if (userNoSecretDTO == null)
                return BadRequest();
            if (userNoSecretDTO.Id != id)
                return BadRequest();
            var userNoSecret = await _userService.Patch(userNoSecretDTO);
            if (userNoSecret == null)
                return NotFound();
            return Ok(userNoSecret);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserNoSecretDTO>> Delete(int id)
        {
            var userNoSecretDTO = await _userService.GetById(id);
            if (userNoSecretDTO == null)
                return NotFound();
            await _userService.Remove(id);
            return Ok(userNoSecretDTO);
        }

    }
}
