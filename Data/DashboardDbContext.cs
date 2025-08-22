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
    
    // on model creating goes here if needed
}