using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LoginSimulator.Models;
using Microsoft.IdentityModel.Tokens;

namespace LoginSimulator.Services;

public class TokenService
{
    public Task GenerateToken(User user)
    {
        if(user.UserName is null) throw new ArgumentNullException("User with null username");

        Claim[] claims = new Claim[]
        {
            new Claim("username", user.UserName),
            new Claim("id", user.Id),
            new Claim(ClaimTypes.DateOfBirth, user.BirthDate.ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Lul"));

        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(expires: DateTime.Now.AddMinutes(10), claims: claims, signingCredentials: signingCredentials);

        return Task.CompletedTask;
    }
}
