using System.ComponentModel.DataAnnotations;

namespace DivinaHamburgueria.API.Models
{
    public class RevokeTokenModel
    {

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid format email")]
        public string Email { get; set; } = string.Empty;

    }
}
