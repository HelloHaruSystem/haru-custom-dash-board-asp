using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalDashBoard.Api.Models;

[Table("login_attempts")]
public class LoginAttempt
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string IpAddress { get; set; }
    
    [Required]
    public string Username { get; set; }
    
    [Required]
    public bool IsSuccessful { get; set; }
    
    [Required]
    public DateTime LoginAttemptAt { get; set; } = DateTime.UtcNow;
    
    // could be operating system
    public string? UserAgent { get; set; }
}