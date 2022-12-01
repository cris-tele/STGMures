using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StgMures.Shared.SesionModels
{
    public class UserLogin
    {
        [Required(ErrorMessage = "Va rugam introduceti adresa de email.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Va rugam introduceti parola de acces in aplicatie.")]
        public string Password { get; set; }
    }
}
