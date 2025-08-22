using Microsoft.EntityFrameworkCore;
using PersonalDashBoard.Api.Models;

namespace PersonalDashBoard.Api.Data;

public class DashboardDbContext : DbContext
{
    public DashboardDbContext(DbContextOptions<DashboardDbContext> options)
        : base(options)
    {
        
    }
    
    // db sets properties to represent tables in the db
    public DbSet<User> Users { get; set; }
    public DbSet<LoginAttempt> LoginAttempts { get; set; }
    
    // on model creating
    // this runs when entity framework is building the model for your database
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // always call base first - base configs are applied
        base.OnModelCreating(modelBuilder);
        
        // All indexes are now defined using [Index] attributes on the models
    }
}