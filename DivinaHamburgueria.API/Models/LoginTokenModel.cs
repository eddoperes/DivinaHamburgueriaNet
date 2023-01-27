﻿using System.ComponentModel.DataAnnotations;

namespace DivinaHamburgueria.API.Models
{
    public class LoginTokenModel
    {

        [Required(ErrorMessage = "Token is required")]
        public string Token { get; set; } = string.Empty;


        [Required(ErrorMessage = "RefreshToken is required")]
        public string RefreshToken { get; set; } = string.Empty;


    }
}
