using PersonalDashBoard.Api.DTOs;
using PersonalDashBoard.Api.Interfaces;
using PersonalDashBoard.Api.Models;

namespace PersonalDashBoard.Api.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly PasswordService _passwordService;
    private readonly IConfiguration _configuration;
    private readonly ILogger<AuthService> _logger;

    public AuthService(IUserRepository userRepository, PasswordService passwordService,
        IConfiguration configuration, ILogger<AuthService> logger)
    {
        _userRepository = userRepository;
        _passwordService = passwordService;
        _configuration = configuration;
        _logger = logger;
    }

    public async Task<RegisterUserResponse> RegisterUserAsync(RegisterUserRequest request)
    {
        try
        {
            // first validate master secret
            string? masterSecret = _configuration["Authentication:MasterSecret"];
            if (string.IsNullOrEmpty(masterSecret) || request.MasterSecret != masterSecret)
            {
                _logger.LogWarning("Invalid master secret attempt for username {0}", request.Username);
                throw new UnauthorizedAccessException("Invalid master secret");
            }
            
            // check if username already exists
            if (await _userRepository.UsernameExistsAsync(request.Username))
            {
                throw new InvalidOperationException("Username already exists");
            }

            // check if email already exists
            if (await _userRepository.EmailExistsAsync(request.Email))
            {
                throw new InvalidOperationException("Email already exists");
            }

            // create new user
            User newUser = new User
            {
                Username = request.Username,
                Email = request.Email,
                CreatedAt = DateTime.UtcNow
            };

            // hash the password
            newUser.PasswordHash = _passwordService.HashPassword(newUser, request.Password);

            // save user to database
            User createdUser = await _userRepository.CreateUserAsync(newUser);

            _logger.LogInformation("User {0} registered successfully", createdUser.Username);

            return new RegisterUserResponse
            {
                Message = "User registered successfully",
                UserId = createdUser.Id,
                UserName = createdUser.Username,
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while registering user {0}", request.Username);
            throw; // re-throw to let controller handle the response
        }
    }
}