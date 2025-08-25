using Microsoft.AspNetCore.Mvc;
using PersonalDashBoard.Api.DTOs;
using PersonalDashBoard.Api.Interfaces;

namespace PersonalDashBoard.Api.Controllers;

/// <summary>
/// Controller responsible for handling authentication related operations
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly ILogger<AuthController> _logger;

    /// <summary>
    /// Initializes a new instance of the authController class
    /// </summary>
    /// <param name="authService">Service for handling authentication operations</param>
    /// <param name="logger">Logger for trackiong controller actions and erros</param>
    public AuthController(IAuthService authService, ILogger<AuthController> logger)
    {
        _authService = authService;
        _logger = logger;
    }

    /// <summary>
    /// Registers a new user in the system
    /// </summary>
    /// <param name="request">User registration request containing username, email, password and master secret</param>
    /// <returns>
    /// 200 OK with registration successful message if successful
    /// 400 Bad Request if username/email already exists or validation fails
    /// 401 Unauthorized if master secret is invalid
    /// 500 Inter Server Error for unexpected errors
    /// </returns>
    /// <response code="200">User registered successfully</response>
    /// <response code="400">Username or email already exists, or validation failed</response>
    /// <response code="401">Invalid master secret provided</response>
    /// <response code="500">An unexpected error occurred during registration</response>
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
            return StatusCode(500, "An error occurred during registration");
        }
    }
}