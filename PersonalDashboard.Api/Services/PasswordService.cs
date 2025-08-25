using Microsoft.AspNetCore.Identity;
using PersonalDashBoard.Api.Models;

namespace PersonalDashBoard.Api.Services;

/// <summary>
/// Service class for password hashing and verification
/// using ASP.NET Core Identity's password hasher
/// </summary>
public class PasswordService
{
    private readonly PasswordHasher<User> _passwordHasher;

    /// <summary>
    /// Initializes a new instance of passwordService with a configured password hasher
    /// </summary>
    public PasswordService()
    {
        _passwordHasher = new PasswordHasher<User>();
    }

    /// <summary>
    /// hashes a plain text password using ASP:NET Core Identity's password hasher
    /// </summary>
    /// <param name="user">User instance for whom the password is being hashed</param>
    /// <param name="plainTextPassword">The plaintext password to hash</param>
    /// <returns>A securely hashed password for database storage</returns>
    public string HashPassword(User user, string plainTextPassword)
    {
        return _passwordHasher.HashPassword(user, plainTextPassword);
    }

    /// <summary>
    /// Verifies if a plain text password matches the stored hash
    /// </summary>
    /// <param name="user">User instance containing the stored hash</param>
    /// <param name="plainTextPassword">plain text password to verify</param>
    /// <returns>True if the password matches the hash, false otherwise</returns>
    public bool VerifyPassword(User user, string plainTextPassword)
    {
        PasswordVerificationResult result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, plainTextPassword);
        return result == PasswordVerificationResult.Success 
               || result == PasswordVerificationResult.SuccessRehashNeeded;
    }
}