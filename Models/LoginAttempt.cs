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
    [Column("ip_address")]
    public string IpAddress { get; set; }
    
    [Required]
    [Column("username")]
    public string Username { get; set; }
    
    [Required]
    [Column("is_successful")]
    public bool IsSuccessful { get; set; }
    
    [Required]
    [Column("attempted_at")]
    public DateTime LoginAttemptAt { get; set; } = DateTime.UtcNow;
    
    // could be operating system
    [Column("user_agent")]
    public string? UserAgent { get; set; }
}