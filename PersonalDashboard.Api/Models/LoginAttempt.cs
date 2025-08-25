using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PersonalDashBoard.Api.Models;

/// <summary>
/// Represents a login attempt record for security monitoring
/// </summary>
[Table("login_attempts")]
[Index(nameof(IpAddress))]
[Index(nameof(Username))]
[Index(nameof(LoginAttemptAt))]
public class LoginAttempt
{
    
    /// <summary>
    /// Gets and sets the unique identifier for the login attempt
    /// </summary>
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    /// <summary>
    /// Gets or sets the IP address from the where the login attempt was made
    /// </summary>
    /// <remarks>
    /// Supports both IPv4 and Ipv6 addresses (max 45 characters for IPv6)
    /// </remarks>
    [Required]
    [MaxLength(45)]
    [Column("ip_address")]
    public string IpAddress { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the username that was attempted during login
    /// </summary>
    /// <remarks>
    /// Records the attempted username even if the user doesn't exist in the system
    /// </remarks>
    [Required]
    [MaxLength(50)]  // Match User.Username length
    [Column("username")]
    public string Username { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets whether the login attempt was successful
    /// </summary>
    [Required]
    [Column("is_successful")]
    public bool IsSuccessful { get; set; }
    
    /// <summary>
    /// Gets or sets the UTC timestamp when the login attempt occurred
    /// </summary>
    [Required]
    [Column("attempted_at")]
    public DateTime LoginAttemptAt { get; set; } = DateTime.UtcNow;
    
    /// <summary>
    /// Gets or sets the User-Agent string from the client that made the login attempt
    /// </summary>
    /// <remarks>
    /// Can be used to identify automated attacks
    /// This may be empty if not provided by the client
    /// </remarks>
    [MaxLength(512)]  // Standard User-Agent header max length
    [Column("user_agent")]
    public string UserAgent { get; set; } = string.Empty;
}