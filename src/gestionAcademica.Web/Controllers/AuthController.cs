using gestionAcademica.Security;
using gestionAcademica.Security.Models;
using Microsoft.AspNetCore.Mvc;

namespace gestionAcademica.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var result = await _authService.LoginAsync(request);
        if (result == null)
        {
            return Unauthorized("Invalid username or password.");
        }

        return Ok(result);
    }

    [HttpGet("logout")]
    public async Task<IActionResult> Logout([FromQuery] string userId)
    {
        var result = await _authService.LogoutAsync(userId);
        if (result == null)
        {
            return NotFound("User not found.");
        }

        return Ok(result);
    }
}
