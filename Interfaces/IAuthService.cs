using PersonalDashBoard.Api.DTOs;

namespace PersonalDashBoard.Api.Interfaces;

public interface IAuthService
{
    public Task<RegisterUserResponse> RegisterUserAsync(RegisterUserRequest request);
}