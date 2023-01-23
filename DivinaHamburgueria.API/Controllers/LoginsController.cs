using DivinaHamburgueria.API.Models;
using DivinaHamburgueria.Application.DTOs;
using DivinaHamburgueria.Application.Interfaces;
using DivinaHamburgueria.Domain.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DivinaHamburgueria.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : Controller
    {

        private readonly ILoginService _loginService;
        private readonly IConfiguration _configuration;

        public LoginsController(ILoginService loginService, IConfiguration configuration)
        {
            _loginService = loginService;
            _configuration = configuration;
        }


        //eddoperes@gmail.com
        //eddoPeres@1

        [AllowAnonymous]
        [HttpPost("LoginUser")]
        public async Task<ActionResult<UserToken>> Login([FromBody] LoginModel userInfo)
        {
  
            var result = await _loginService.ValidateCredentials(userInfo.Email, userInfo.Password,
                                                                _configuration["Jwt:SecretKey"],
                                                                int.Parse(_configuration["Jwt:Minutes"]),
                                                                _configuration["Jwt:Issuer"],
                                                                _configuration["Jwt:Audience"],
                                                                int.Parse(_configuration["Jwt:DaysToExpire"]));
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return BadRequest(ModelState);
            }
        }

        [AllowAnonymous]
        [HttpPost("LoginWithRefreshToken")]
        public async Task<ActionResult<UserToken>> LoginWithRefreshToken([FromBody] LoginTokenModel tokenInfo)
        {

            var result = await _loginService.ValidateCredentials(tokenInfo.Token, tokenInfo.RefreshToken,
                                                                _configuration["Jwt:SecretKey"],
                                                                int.Parse(_configuration["Jwt:Minutes"]),
                                                                _configuration["Jwt:Issuer"],
                                                                _configuration["Jwt:Audience"]);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return BadRequest(ModelState);
            }
        }


    }
}
