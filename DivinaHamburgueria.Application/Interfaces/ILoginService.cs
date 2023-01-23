using DivinaHamburgueria.Application.DTOs;
using DivinaHamburgueria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Application.Interfaces
{
    public interface ILoginService
    {

        Task<TokenDTO?> ValidateCredentials(string email, string password, 
                                            string secretKey, double minutes,
                                            string issuer, string audience,
                                            int daysToExpire);

        Task<TokenDTO?> ValidateCredentials(string token, string refreshToken,
                                            string secretKey, double minutes,
                                            string issuer, string audience);

        Task<bool> RevokeToken(string email);

    }
}
