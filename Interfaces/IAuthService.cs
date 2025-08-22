using PersonalDashBoard.Api.DTOs;

namespace PersonalDashBoard.Api.Interfaces;

/// <summary>
/// Service interface for authentication operations
/// </summary>
public interface IAuthService
{
    
    /// <summary>
    /// Registers a new user in the system after validation
    /// </summary>
    /// <param name="request">Registration request containing user details and master secret</param>
    /// <returns>Registration response with success information</returns>
    /// <exception cref="UnauthorizedAccessException">Thrown when master secret is invalid</exception>
    /// <exception cref="InvalidOperationException">Thrown when username or email already exists</exception>
    public Task<RegisterUserResponse> RegisterUserAsync(RegisterUserRequest request);
}