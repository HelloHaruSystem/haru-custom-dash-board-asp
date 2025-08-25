using Microsoft.EntityFrameworkCore;
using PersonalDashBoard.Api.Models;

namespace PersonalDashBoard.Api.Data;

/// <summary>
/// Entity Framework DbContext for the dashboard application
/// </summary>
/// <remarks>
/// Manages database connections and provides access to Users and LoginAttempts tables.
/// Configured to use SQLite for development and PostgreSQL for production environments.
/// </remarks>
public class DashboardDbContext : DbContext
{
    
    /// <summary>
    /// Initializes a new instance of the DashboardDbContext
    /// </summary>
    /// <param name="options">Configuration options for the database context</param>
    public DashboardDbContext(DbContextOptions<DashboardDbContext> options)
        : base(options)
    {
        
    }
    
    /// <summary>
    /// Gets or sets the DbSet for User entities
    /// </summary>
    /// <remarks>
    /// Represents the dashboard_users table in the database
    /// </remarks>
    public DbSet<User> Users { get; set; }
    
    /// <summary>
    /// Gets or sets the DbSet for LoginAttempt entities
    /// </summary>
    /// <remarks>
    /// Represents the login_attempts table used for security monitoring and rate limiting
    /// </remarks>
    public DbSet<LoginAttempt> LoginAttempts { get; set; }
    
    // on model creating goes here if needed
}