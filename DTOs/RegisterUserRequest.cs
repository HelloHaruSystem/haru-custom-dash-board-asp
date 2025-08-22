using System.ComponentModel.DataAnnotations;

namespace PersonalDashBoard.Api.DTOs;

public record RegisterUserRequest
{
    private const int UsernameMaxLength = 50;
    private const int UsernameMinLength = 3;
    private const int PasswordMaxLength = 100;
    private const int PasswordMinLength = 6;
    
    [Required]
    [StringLength(UsernameMaxLength, MinimumLength = UsernameMinLength)]
    public string Username { get; init; } = string.Empty;
    
    [Required]
    [EmailAddress]
    public string Email { get; init; } = string.Empty;
    
    [Required]
    [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength)]
    public string Password { get; init; } = string.Empty;
    
    [Required]
    public string MasterSecret { get; init; } = string.Empty;
}