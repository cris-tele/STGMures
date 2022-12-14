using System.ComponentModel.DataAnnotations;

namespace StgMures.Shared.Dto
{
    public class UserLogin
    {
        [Required(ErrorMessage = "Va rugam introduceti adresa de email.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Va rugam introduceti parola de acces in aplicatie.")]
        public string Password { get; set; }
    }
}
