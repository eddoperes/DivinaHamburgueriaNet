using DivinaHamburgueria.Application.DTOs;
using DivinaHamburgueria.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DivinaHamburgueria.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UnidadesController : Controller
    {

        private readonly IUnidadeService _unidadeService;

        public UnidadesController(IUnidadeService unidadeService)
        {
            _unidadeService = unidadeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnidadeDTO>>> Get()
        {
            var unidades = await _unidadeService.GetAll();
            return Ok(unidades);
        }

        [HttpGet("{id}", Name = "GetUnidade")]
        public async Task<ActionResult<UnidadeDTO>> Get(int id)
        {
            var unidade = await _unidadeService.GetById(id);
            if (unidade == null)
                return NotFound();
            return Ok(unidade);
        }

        [HttpPost]
        public async Task<ActionResult<UnidadeDTO>> Post([FromBody] UnidadeDTO unidade)
        {
            if (unidade == null)
                return BadRequest();
            await _unidadeService.Add(unidade);
            return new CreatedAtRouteResult("GetUnidade", new { id = unidade.Id }, unidade);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UnidadeDTO>> Put(int id, [FromBody] UnidadeDTO unidade)
        {
            if (unidade == null)
                return BadRequest();
            if (unidade.Id != id)
                return BadRequest();
            await _unidadeService.Update(unidade);
            return Ok(unidade);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UnidadeDTO>> Delete(int id)
        {
            var unidade = await _unidadeService.GetById(id);
            if (unidade == null)
                return NotFound();
            await _unidadeService.Remove(id);
            return Ok(unidade);
        }

    }
}
