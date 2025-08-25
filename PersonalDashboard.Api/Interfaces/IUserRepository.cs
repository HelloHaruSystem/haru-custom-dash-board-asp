using PersonalDashBoard.Api.Models;

namespace PersonalDashBoard.Api.Interfaces;

/// <summary>
/// Repository interface for user data access operations
/// </summary>
public interface IUserRepository
{
    
    /// <summary>
    /// Retrieves a user by their username
    /// </summary>
    /// <param name="username">The username to search for</param>
    /// <returns>The user if found, null otherwise</returns>
    public Task<User?> GetByUsernameAsync(string username);
    
    /// <summary>
    /// Retrieves a user by their email address
    /// </summary>
    /// <param name="email">The email to search for</param>
    /// <returns>The user if found, null otherwise</returns>
    public Task<User?> GetByEmailAsync(string email);
    
    /// <summary>
    /// Checks if a username already exists in the system
    /// </summary>
    /// <param name="username">The username to check</param>
    /// <returns>True if username exists, false otherwise</returns>
    public Task<bool> UsernameExistsAsync(string username);
    
    /// <summary>
    /// Checks if an email already exists in the system
    /// </summary>
    /// <param name="email">The email to check</param>
    /// <returns>True if email exists, false otherwise</returns>
    public Task<bool> EmailExistsAsync(string email);
    
    /// <summary>
    /// Creates a new user in the database
    /// </summary>
    /// <param name="user">The user entity to create</param>
    /// <returns>The created user with populated database values</returns>
    public Task<User> CreateUserAsync(User user);
}