using Microsoft.EntityFrameworkCore;
using PersonalDashBoard.Api.Data;
using PersonalDashBoard.Api.Interfaces;
using PersonalDashBoard.Api.Models;

namespace PersonalDashBoard.Api.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DashboardDbContext _context;

    public UserRepository(DashboardDbContext context)
    {
        _context = context;
    }
    
    public async Task<User?> GetByUsernameAsync(string username)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Username == username);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<bool> UsernameExistsAsync(string username)
    {
        return await _context.Users
            .AnyAsync(u => u.Username == username);
    }

    public async Task<bool> EmailExistsAsync(string email)
    {
        return await _context.Users
            .AnyAsync(u => u.Email == email);
    }

    public async Task<User> CreateUserAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }
}