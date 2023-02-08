using Microsoft.AspNetCore.Mvc;

namespace StgMures.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;

        public AuthController(IAuthRepository authRepo)
        {
            _authRepo = authRepo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegister request)
        {
        var response = await _authRepo.Register(
                new Medic
                {
                    Name = request.Name,
                    Email = request.Email,
                    Code = request.Code,
                    Specialty= request.Specialty,
                    Note = request.Note,
                    IsConfirmed = request.IsConfirmed
                },
                request.Password
                );

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLogin request)
        {
            var response = await _authRepo.Login(
                request.Email, request.Password);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
