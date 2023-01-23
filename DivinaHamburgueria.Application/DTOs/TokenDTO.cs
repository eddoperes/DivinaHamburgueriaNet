﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DivinaHamburgueria.Application.DTOs
{
    public class TokenDTO
    {

        public TokenDTO(bool autenticated, string created, string expiration, string accessToken, string refreshToken)
        {
            Autenticated = autenticated;
            Created = created;
            Expiration = expiration;
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }

        public bool Autenticated { get; set; }

        public string Created { get; set; }

        public string Expiration { get; set; }

        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }

    }
}
