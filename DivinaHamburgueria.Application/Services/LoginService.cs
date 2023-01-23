using AutoMapper;
using DivinaHamburgueria.Application.DTOs;
using DivinaHamburgueria.Application.Interfaces;
using DivinaHamburgueria.Domain.Account;
using DivinaHamburgueria.Domain.Entities;
using DivinaHamburgueria.Domain.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Application.Services
{
    public class LoginService : ILoginService
    {

        private const string DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";
        private IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public LoginService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<TokenDTO?> ValidateCredentials(string email, string password, 
                                                         string secretKey, double minutes, 
                                                         string issuer, string audience, 
                                                         int daysToExpire)
        {            
            var user = await _userRepository.ValidateCredentials(email, password);
            if (user == null)
                return null;
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Email)
            };
            var accessToken = GenerateAccessToken(claims, secretKey, minutes, issuer, audience);
            var refreshToken = GenerateRefreshToken();
            user.NotifyRefreshToken(refreshToken);
            user.NotifyRefreshTokenExpire(DateTime.Now.AddDays(daysToExpire));
            await _userRepository.RefreshUserInfo(user);
            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate.AddMinutes(minutes);
            return new TokenDTO(
                                true,
                                createDate.ToString(DATE_FORMAT),
                                expirationDate.ToString(DATE_FORMAT),
                                accessToken,
                                refreshToken
                                );
        }

        public async Task<TokenDTO?> ValidateCredentials(string accessToken, string refreshToken,  
                                                         string secretKey, double minutes, 
                                                         string issuer, string audience)
        {


            var principal = GetPrincipalFromExpiredToken(accessToken, secretKey);
            var email = principal.Identity.Name;

            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null)
                return null;
            if (user.RefreshToken != refreshToken || user.RefreshTokenExpire <= DateTime.Now)
                return null;

            accessToken = GenerateAccessToken(principal.Claims, secretKey, minutes, issuer, audience);
            refreshToken = GenerateRefreshToken();
            user.NotifyRefreshToken(refreshToken);

            await _userRepository.RefreshUserInfo(user);
            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate.AddMinutes(minutes);
            return new TokenDTO(
                                true,
                                createDate.ToString(DATE_FORMAT),
                                expirationDate.ToString(DATE_FORMAT),
                                accessToken,
                                refreshToken
                                );
        }

        public async Task<bool> RevokeToken(string email)
        {
            return await _userRepository.RevokeToken(email);
        }

        private string GenerateAccessToken(IEnumerable<Claim> claims, string secretKey, 
                                             double minutes, string issuer, string audience)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddMinutes(minutes);
            var options = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: expiration,
                signingCredentials: signingCredentials
            );
            string tokenString = new JwtSecurityTokenHandler().WriteToken(options);
            return tokenString;
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token, string secretKey)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                ValidateLifetime = false
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            ClaimsPrincipal principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (securityToken == null ||
                !jwtSecurityToken!.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCulture))
            {
                throw new SecurityTokenException("Invalid token");
            }
            return principal;
        }



    }
}
