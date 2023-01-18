using DivinaHamburgueria.Application.DTOs;
using DivinaHamburgueria.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DivinaHamburgueria.API.Controllers
{

    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {

        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> Get()
        {
            var customerDTOs = await _customerService.GetAll();
            return Ok(customerDTOs);
        }

        [HttpGet("GetByName")]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetByName([FromQuery] string? name)
        {
            var customerDTOs = await _customerService.GetByName(name);
            return Ok(customerDTOs);
        }

        [HttpGet("{id}", Name = "GetCustomer")]
        public async Task<ActionResult<CustomerDTO>> Get(int id)
        {
            var customerDTO = await _customerService.GetById(id);
            if (customerDTO == null)
                return NotFound();
            return Ok(customerDTO);
        }

        [HttpPost]
        public async Task<ActionResult<CustomerDTO>> Post([FromBody] CustomerDTO customerDTO)
        {
            try
            {
                if (customerDTO == null)
                    return BadRequest();
                await _customerService.Add(customerDTO);
                return new CreatedAtRouteResult("GetCustomer", new { id = customerDTO.Id }, customerDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CustomerDTO>> Put(int id, [FromBody] CustomerDTO customerDTO)
        {
            try
            {
                if (customerDTO == null)
                    return BadRequest();
                if (customerDTO.Id != id)
                    return BadRequest();
                await _customerService.Update(customerDTO);
                return Ok(customerDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CustomerDTO>> Delete(int id)
        {
            var customerDTO = await _customerService.GetById(id);
            if (customerDTO == null)
                return NotFound();
            await _customerService.Remove(id);
            return Ok(customerDTO);
        }

    }
}
