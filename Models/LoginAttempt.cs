using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PersonalDashBoard.Api.Models;

[Table("login_attempts")]
[Index(nameof(IpAddress))]
[Index(nameof(Username))]
[Index(nameof(LoginAttemptAt))]
public class LoginAttempt
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(45)]  // IPv6 max length
    [Column("ip_address")]
    public string IpAddress { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(50)]  // Match User.Username length
    [Column("username")]
    public string Username { get; set; } = string.Empty;
    
    [Required]
    [Column("is_successful")]
    public bool IsSuccessful { get; set; }
    
    [Required]
    [Column("attempted_at")]
    public DateTime LoginAttemptAt { get; set; } = DateTime.UtcNow;
    
    [MaxLength(512)]  // Standard User-Agent header max length
    [Column("user_agent")]
    public string UserAgent { get; set; } = string.Empty;
}