using TodoApi.DTOs.Authentication;

namespace TodoApi.Services;

public interface IAuthManager
{
    Task<IEnumerable<ErrorReponseDto>> Register(RegisterDto registerDto);

    Task<AuthResponseDto?> Login(LoginDto loginDto);
}
