using Microsoft.EntityFrameworkCore;
using PersonalDashBoard.Api.Data;
using PersonalDashBoard.Api.Interfaces;
using PersonalDashBoard.Api.Models;

namespace PersonalDashBoard.Api.Repositories;

/// <summary>
/// Repository class for user data access using Entity Framework Core
/// </summary>
public class UserRepository : IUserRepository
{
    private readonly DashboardDbContext _context;

    /// <summary>
    /// Initializes a new instance of the UserRepository
    /// </summary>
    /// <param name="context">The database context for user operations</param>
    public UserRepository(DashboardDbContext context)
    {
        _context = context;
    }
    
    /// <summary>
    /// Retrieves a user by their username
    /// </summary>
    /// <param name="username">The username to search for</param>
    /// <returns>The user if found, null otherwise</returns>
    public async Task<User?> GetByUsernameAsync(string username)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Username == username);
    }

    /// <summary>
    /// Retrieves a user by their email
    /// </summary>
    /// <param name="email">The email address to search for</param>
    /// <returns>the user if found, null otherwise</returns>
    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Email == email);
    }

    /// <summary>
    /// Checks if a username already exists in the system
    /// </summary>
    /// <param name="username">The username to check for existence</param>
    /// <returns>True if the username exists, otherwise false</returns>
    public async Task<bool> UsernameExistsAsync(string username)
    {
        return await _context.Users
            .AnyAsync(u => u.Username == username);
    }

    /// <summary>
    /// Checks if an email address already exists in the system
    /// </summary>
    /// <param name="email">The email address to check for existence</param>
    /// <returns>True if the username exists, otherwise false</returns>
    public async Task<bool> EmailExistsAsync(string email)
    {
        return await _context.Users
            .AnyAsync(u => u.Email == email);
    }

    /// <summary>
    /// Creates a new user in the database
    /// </summary>
    /// <param name="user">The user entity to create</param>
    /// <returns>The created user with any database-generated values populated</returns>
    /// <exception cref="DbUpdateException">Thrown when database constraints are violated or other database errors occur</exception>
    public async Task<User> CreateUserAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }
}