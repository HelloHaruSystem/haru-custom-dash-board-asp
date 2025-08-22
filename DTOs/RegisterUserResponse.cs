namespace PersonalDashBoard.Api.DTOs;

public record RegisterUserResponse()
{
    public string Message { get; init; } = string.Empty;
    public int UserId { get; init; }
    public string UserName { get; init; } = string.Empty;
}