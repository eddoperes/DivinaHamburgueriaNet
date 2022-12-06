using DivinaHamburgueria.Application.DTOs;
using DivinaHamburgueria.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DivinaHamburgueria.API.Controllers
{

    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class UnitsController : Controller
    {

        private readonly IUnityService _unityService;

        public UnitsController(IUnityService unityService)
        {
            _unityService = unityService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnityDTO>>> Get()
        {
            var unidades = await _unityService.GetAll();
            return Ok(unidades);
        }

        [HttpGet("{id}", Name = "GetUnity")]
        public async Task<ActionResult<UnityDTO>> Get(int id)
        {
            var unity = await _unityService.GetById(id);
            if (unity == null)
                return NotFound();
            return Ok(unity);
        }

        [HttpPost]
        public async Task<ActionResult<UnityDTO>> Post([FromBody] UnityDTO unityDTO)
        {
            if (unityDTO == null)
                return BadRequest();
            await _unityService.Add(unityDTO);
            return new CreatedAtRouteResult("GetUnity", new { id = unityDTO.Id }, unityDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UnityDTO>> Put(int id, [FromBody] UnityDTO unityDTO)
        {
            if (unityDTO == null)
                return BadRequest();
            if (unityDTO.Id != id)
                return BadRequest();
            await _unityService.Update(unityDTO);
            return Ok(unityDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UnityDTO>> Delete(int id)
        {
            var unityDTO = await _unityService.GetById(id);
            if (unityDTO == null)
                return NotFound();
            await _unityService.Remove(id);
            return Ok(unityDTO);
        }

    }
}
