using PersonalDashBoard.Api.DTOs;
using PersonalDashBoard.Api.Interfaces;
using PersonalDashBoard.Api.Models;

namespace PersonalDashBoard.Api.Services;

/// <summary>
/// Service responsible for handling authentication including user registration and validation
/// </summary>
public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly PasswordService _passwordService;
    private readonly IConfiguration _configuration;
    private readonly ILogger<AuthService> _logger;

    /// <summary>
    /// Initializes a new instance of the AuthService
    /// </summary>
    /// <param name="userRepository">Repository for user data</param>
    /// <param name="passwordService">Service for password hashing and verification</param>
    /// <param name="configuration">Application configurations needed for authentication settings</param>
    /// <param name="logger">Logger for authentication events and errors</param>
    public AuthService(IUserRepository userRepository, PasswordService passwordService,
        IConfiguration configuration, ILogger<AuthService> logger)
    {
        _userRepository = userRepository;
        _passwordService = passwordService;
        _configuration = configuration;
        _logger = logger;
    }

    /// <summary>
    /// Register a new user in the system after validation the master secret and checking for duplicate username or password
    /// </summary>
    /// <param name="request">User registration request containing username, email, password and master secret</param>
    /// <returns>A response indication successful registration with the created user</returns>
    /// <exception cref="UnauthorizedAccessException">Thrown when master secret is invalid or missing</exception>
    /// <exception cref="InvalidOperationException">Thrown when username or email already exists in the system</exception>
    /// <exception cref="Exception">Thrown for any unexpected errors during registration</exception>
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