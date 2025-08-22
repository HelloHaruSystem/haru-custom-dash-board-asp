using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PersonalDashBoard.Api.Models;

[Table("dashboard_users")]
[Index(nameof(Username), IsUnique = true)]
[Index(nameof(Email), IsUnique = true)]
public class User
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(50)]
    [Column("username")]
    public string Username { get; set; }
    
    [Required]
    [EmailAddress]
    [Column("email")]
    public string Email { get; set; }
    
    [Required]
    [Column("password_hash")]
    public string PasswordHash { get; set; }

    [Required]
    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    [Required]
    [Column("is_admin")]
    public bool IsAdmin { get; set; } = false;
}