#nullable disable
using System.ComponentModel.DataAnnotations;

namespace StgMures.Shared.SesionModels
{
    public class UserRegister
    {
        [Required, StringLength(150, ErrorMessage = "Nume si Prenume (150 caractere max).")]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }


        [StringLength(50, ErrorMessage = "Cod parafa, (max 50 caractere).")]
        public string Code { get; set; }

        [StringLength(50, ErrorMessage = "Specializare, (max 50 caractere).")]
        public string Specialty { get; set; }

        [Required, StringLength(100, MinimumLength = 6)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Confirmarea parolei a esuat. Introduceti aceeasi parola, atentie la Caps-Lock")]
        public string ConfirmPassword { get; set; }


        [StringLength(250, ErrorMessage = "Adnotari, (max 250 caractere).")]
        public string Note { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool IsConfirmed { get; set; } = true; // already registered

    }
}
