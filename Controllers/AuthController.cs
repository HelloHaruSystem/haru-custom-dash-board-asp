using Microsoft.AspNetCore.Mvc;
using PersonalDashBoard.Api.DTOs;
using PersonalDashBoard.Api.Interfaces;

namespace PersonalDashBoard.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly ILogger<AuthController> _logger;

    public AuthController(IAuthService authService, ILogger<AuthController> logger)
    {
        _authService = authService;
        _logger = logger;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserRequest request)
    {
        try
        {
            RegisterUserResponse response = await _authService.RegisterUserAsync(request);
            return Ok(response);
        }
        catch (UnauthorizedAccessException ex)
        {
            _logger.LogWarning("Unauthorized registration attempt: {0}", ex.Message);
            return Unauthorized();
        }
        catch (InvalidOperationException ex)
        {
            _logger.LogWarning("Registration failed: {0}", ex.Message);
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unexpected error during registration");
            return StatusCode(500, "An error occured during registration");
        }
    }
}