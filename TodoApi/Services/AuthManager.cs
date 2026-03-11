using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using StudentEnrollment.Data;
using TodoApi.DTOs.Authentication;

namespace TodoApi.Services;

public class AuthManager : IAuthManager
{
    private readonly UserManager<SchoolUser> _userManager;
    private readonly IConfiguration _configuration;
    public AuthManager(UserManager<SchoolUser> userManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
    }
    public async Task<IEnumerable<ErrorReponseDto>> Register(RegisterDto registerDto)
    {
        var user = new SchoolUser
        {
            UserName = registerDto.EmailAddress,
            Email = registerDto.EmailAddress,
            FirstName = registerDto.FirstName,
            LastName = registerDto.LastName,
            DateOfBirth = registerDto.DateOfBirth
        };
        var result = await _userManager.CreateAsync(user, registerDto.Password);
        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, "User");
            return Array.Empty<ErrorReponseDto>();
        }
        return result.Errors.Select(e => new ErrorReponseDto { Description = e.Description, Code = e.Code });
    }

    public async Task<AuthResponseDto?> Login(LoginDto loginDto)
    {
        var user = await _userManager.FindByEmailAsync(loginDto.EmailAddress);
        if (user == null)
            return null;
        var isValidPassword = await _userManager.CheckPasswordAsync(user, loginDto.Password);
        if (!isValidPassword)
            return null;

        var token = await GenerateTokenAsync(user);
        return new AuthResponseDto
        {
            Token = token,
            UserId = user.Id,
        };
    }

    private async Task<string> GenerateTokenAsync(SchoolUser user)
    {
        var jwtKey = _configuration["JwtSettings:Key"];
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var roles = await _userManager.GetRolesAsync(user);
        var roleClaims = roles.Select(r => new Claim(ClaimTypes.Role, r)).ToList();
        var userClaims = await _userManager.GetClaimsAsync(user);

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Email ),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email ),
            new Claim("userId", user.Id)
        }.Union(userClaims).Union(roleClaims);

        var token = new JwtSecurityToken(
            issuer: _configuration["JwtSettings:Issuer"],
            audience: _configuration["JwtSettings:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(Convert.ToInt32(_configuration["JwtSettings:DurationInHours"])),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

}
