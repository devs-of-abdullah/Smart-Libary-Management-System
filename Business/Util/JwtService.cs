using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class JwtService
{
    private readonly string _key;
    private readonly string _issuer;
    private readonly string _audience;
    private readonly int _expireMinutes;

    public JwtService(IConfiguration config)
    {
        _key = config["Jwt:Key"] ?? throw new InvalidOperationException("JWT Key is missing");
        _issuer = config["Jwt:Issuer"] ?? throw new InvalidOperationException("JWT Issuer is missing");
        _audience = config["Jwt:Audience"] ?? throw new InvalidOperationException("JWT Audience is missing");
        _expireMinutes = int.Parse(config["Jwt:ExpireMinutes"] ?? "120");
    }

    public string GenerateToken(int staffId, string role)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, staffId.ToString()),
            new Claim(ClaimTypes.Role, role)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _issuer,
            audience: _audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_expireMinutes),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
