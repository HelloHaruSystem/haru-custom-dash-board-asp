using Microsoft.AspNetCore.Identity;
using PersonalDashBoard.Api.Models;

namespace PersonalDashBoard.Api.Services;

public class PasswordService
{
    private readonly PasswordHasher<User> _passwordHasher;

    public PasswordService()
    {
        _passwordHasher = new PasswordHasher<User>();
    }

    /// <summary>
    /// Takes a plain text password and returns a hashed version
    /// </summary>
    /// <param name="user">User instance</param>
    /// <param name="plainTextPassword">The password to hash</param>
    /// <returns></returns>
    public string HashPassword(User user, string plainTextPassword)
    {
        return _passwordHasher.HashPassword(user, plainTextPassword);
    }

    /// <summary>
    /// Checks if a plain text password matches the stored hash
    /// Returns true if they match
    /// returns false if they don't
    /// </summary>
    /// <param name="user">User instance</param>
    /// <param name="plainTextPassword">Password to compare with</param>
    /// <returns></returns>
    public bool VerifyPassword(User user, string plainTextPassword)
    {
        PasswordVerificationResult result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, plainTextPassword);
        return result == PasswordVerificationResult.Success 
               || result == PasswordVerificationResult.SuccessRehashNeeded;
    }
}