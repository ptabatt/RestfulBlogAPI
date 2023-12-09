using Microsoft.AspNetCore.Mvc;
using System.Net;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    IAuthService _authService;
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterDto registerDto)
    {
        var token = _authService.Register(registerDto);
        return Ok(new { Token = token });
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginDto loginDto)
    {
        var token = _authService.Login(loginDto);
        if (token == null || token.IsFaulted)
        {
            return Unauthorized();
        }

        return Ok(new { Token = token });
    }
}
