using PersonalDashBoard.Api.Models;

namespace PersonalDashBoard.Api.Interfaces;

public interface IUserRepository
{
    public Task<User?> GetByUsernameAsync(string username);
    public Task<User?> GetByEmailAsync(string email);
    public Task<bool> UsernameExistsAsync(string username);
    public Task<bool> EmailExistsAsync(string email);
    public Task<User> CreateUserAsync(User user);
}