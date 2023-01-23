using DivinaHamburgueria.Application.DTOs;
using DivinaHamburgueria.Application.Interfaces;
using DivinaHamburgueria.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DivinaHamburgueria.API.Controllers
{

    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {

        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> Get()
        {
            var userDTOs = await _userService.GetAll();
            var userDTOsList = userDTOs.ToList();
            for (int i = 0; i < userDTOsList.Count ; i++)
            {
                userDTOsList[i].Password = "********";
            }
            return Ok(userDTOsList);
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> Post([FromBody] UserDTO userDTO)
        {
            try
            {
                if (userDTO == null)
                    return BadRequest();
                await _userService.Add(userDTO);
                userDTO.Password = "********";
                return Ok(userDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }



    }
}
