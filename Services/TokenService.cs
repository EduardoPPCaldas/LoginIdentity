using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LoginSimulator.Models;
using Microsoft.IdentityModel.Tokens;

namespace LoginSimulator.Services;

public class TokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken(User user)
    {
        if(user.UserName is null) throw new InvalidOperationException("User with null username");

        Claim[] claims = new Claim[]
        {
            new Claim("username", user.UserName),
            new Claim("id", user.Id),
            new Claim(ClaimTypes.DateOfBirth, user.BirthDate.ToString()),
            new Claim("loginTimestamp", DateTimeOffset.Now.ToString())
        };

        var securityWord = _configuration.GetRequiredSection("SymmetricSecurityKey").Value ?? throw new InvalidOperationException("Key is null");

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityWord));

        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(expires: DateTime.Now.AddMinutes(10), claims: claims, signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
