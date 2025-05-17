using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ebaybe.Repositories;
using Microsoft.IdentityModel.Tokens;

namespace ebaybe.Services;

public interface IAuthService
{
        Task<string?> Login(string email, string password);

}

public class AuthService : IAuthService
{
    private readonly IConfiguration _config;
    private readonly IUserRepository _userRepository;

    public AuthService(IConfiguration config,
        IUserRepository userRepository)
    {
        _userRepository = userRepository;
        _config = config;
    }
     public async Task<string?> Login(string email, string password)
    {
        var user = await _userRepository.GetByEmailAndPassword(email, password);
        if (user is null) return null;

        var token = GenerateToken(user.Email);
        return token;
    }

    private string GenerateToken(string email)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: new[] { new Claim(ClaimTypes.Name, email) },
            expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(_config["Jwt:ExpiresInMinutes"]!)),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}