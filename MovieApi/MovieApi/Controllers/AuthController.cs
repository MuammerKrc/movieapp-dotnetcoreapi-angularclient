using CoreLayer.Dtos.IdentityDtos;
using CoreLayer.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto login)
        {
            var result = await _authService.LoginAsync(login);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> LoginWithRefreshToken(string refreshToken)
        {
            var result=await _authService.RefreshTokenLoginAsync(refreshToken);
            return Ok(result);
        }
    }
}
