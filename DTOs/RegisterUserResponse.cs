namespace PersonalDashBoard.Api.DTOs;

/// <summary>
/// Response model for successful user registration
/// </summary>
public record RegisterUserResponse
{
    
    /// <summary>
    /// Gets the success message indicating the registration result
    /// </summary>
    public string Message { get; init; } = string.Empty;
    
    /// <summary>
    /// Gets the username of the successfully registered user
    /// </summary>
    public string UserName { get; init; } = string.Empty;
}