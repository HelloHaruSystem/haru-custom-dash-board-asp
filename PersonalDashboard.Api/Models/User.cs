using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PersonalDashBoard.Api.Models;

/// <summary>
/// Represents a user in the dashboard system
/// </summary>
[Table("dashboard_users")]
[Index(nameof(Username), IsUnique = true)]
[Index(nameof(Email), IsUnique = true)]
public class User
{
    
    /// <summary>
    /// Gets or sets the unique identifiers for the user
    /// </summary>
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    /// <summary>
    /// Gets or sets the unique username for the user
    /// </summary>
    /// <remarks>myst be between 3-50 characters and unique across all users</remarks>
    [Required]
    [MaxLength(50)]
    [Column("username")]
    public string Username { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the unique email address for the user
    /// </summary>
    /// <remarks>
    /// Must be a valid email format and unique across all users
    /// Maximum length follows the RFC 532 standard (320 characters)
    /// </remarks>
    [Required]
    [EmailAddress]
    [MaxLength(320)]
    [Column("email")]
    public string Email { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the hashed password for the user
    /// </summary>
    /// <remarks>
    /// This field stores the output from ASP:NET Core Identity's passwordHasher
    /// NEVER store plain text passwords in this field
    /// </remarks>
    [Required]
    [MaxLength(500)]  // room for hashed passwords
    [Column("password_hash")]
    public string PasswordHash { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the UTC timestamp when the user account was created
    /// </summary>
    [Required]
    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    /// <summary>
    /// Gets or sets whether the user has admin privileges
    /// </summary>
    /// <remarks>
    /// Defaults to false for all new users
    /// </remarks>
    [Required]
    [Column("is_admin")]
    public bool IsAdmin { get; set; } = false;
}