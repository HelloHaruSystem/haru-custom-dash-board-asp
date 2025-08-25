using System.ComponentModel.DataAnnotations;

namespace PersonalDashBoard.Api.DTOs;

/// <summary>
/// Request model for user registration containing all required user information and authentication
/// </summary>
public record RegisterUserRequest
{
    private const int UsernameMaxLength = 50;
    private const int UsernameMinLength = 3;
    private const int PasswordMaxLength = 100;
    private const int PasswordMinLength = 6;
    
    /// <summary>
    /// Gets the desired username for the new account
    /// </summary>
    /// <remarks>
    /// Must be between 3-50 characters and will be checked for uniqueness
    /// </remarks>
    [Required]
    [StringLength(UsernameMaxLength, MinimumLength = UsernameMinLength)]
    public string Username { get; init; } = string.Empty;
    
    /// <summary>
    /// Gets the email address for the new account
    /// </summary>
    /// <remarks>
    /// Must be a valid email format and will be checked for uniqueness
    /// </remarks>
    [Required]
    [EmailAddress]
    public string Email { get; init; } = string.Empty;
    
    /// <summary>
    /// Gets the plain text password for the new account
    /// </summary>
    /// <remarks>
    /// Must be between 6-100 characters. Will be securely hashed before storage.
    /// </remarks>
    [Required]
    [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength)]
    public string Password { get; init; } = string.Empty;
    
    /// <summary>
    /// Gets the master secret required for registration authorization
    /// </summary>
    /// <remarks>
    /// Must match the configured master secret in application settings to allow registration
    /// </remarks>
    [Required]
    public string MasterSecret { get; init; } = string.Empty;
}