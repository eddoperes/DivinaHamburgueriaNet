using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using DivinaHamburgueria.Domain.Account;
using DivinaHamburgueria.API.Models;

namespace DivinaHamburgueria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokensController : ControllerBase
    {

        private readonly IAuthenticate _authenticate;
        private readonly IConfiguration _configuration;

        public TokensController(IAuthenticate authenticate, IConfiguration configuration)
        {
            _authenticate = authenticate;
            _configuration = configuration;
        }

        //[ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost("CreateUser")]        
        public async Task<ActionResult<UserToken>> CreateUser([FromBody] LoginModel userInfo)
        {
            var result = await _authenticate.RegisterUser(userInfo.Email, userInfo.Password);
            if (result)
            {
                return Ok($"User {userInfo.Email} was created successfully.");
            }
            else
            {
                ModelState.AddModelError(string.Empty, $"Create user {userInfo.Email} failed.");
                return BadRequest(ModelState);
            }
        }

        //eddoperes@gmail.com
        //eddoPeres@1

        [AllowAnonymous]
        [HttpPost("LoginUser")]
        public async Task<ActionResult<UserToken>> Login([FromBody]LoginModel userInfo)
        {
            var result = await _authenticate.Authenticate(userInfo.Email, userInfo.Password);
            if (result)
            {
                return GenerateToken(userInfo);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return BadRequest(ModelState) ;
            }
        }

        private UserToken GenerateToken(LoginModel userInfo)
        {
            var claims = new[]
            {
                new Claim("email", userInfo.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };
            //generate private key
            var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            //generate digital signature
            var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256); 
            //time to token expire
            var expiration = DateTime.UtcNow.AddMinutes(double.Parse(_configuration["Jwt:Minutes"]));
            //generate token
            var token = new JwtSecurityToken(issuer : _configuration["Jwt:Issuer"],
                                             audience : _configuration["Jwt:Audience"],
                                             claims: claims,
                                             expires: expiration,
                                             signingCredentials: credentials);
            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration,
            }; 
        }







    }
}
