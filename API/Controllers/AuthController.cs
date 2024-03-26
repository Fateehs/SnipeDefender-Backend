using Application.Abstractions.Services;
using Application.Features;
using Application.Model.Login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ITokenService _tokenService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<UserLoginResponse>> LoginUserAsync([FromBody] UserLoginRequest request)
        {
            var result = await _authService.LoginUserAsync(request);

            return result;
        }

        [HttpPost("validate")]
        [AllowAnonymous]
        public async Task<ActionResult<bool>> ValidateTokenAsync([FromBody] string token)
        {
            var isValid = await _tokenService.ValidateTokenAsync(token);

            return Ok(isValid);
        }
    }
}
