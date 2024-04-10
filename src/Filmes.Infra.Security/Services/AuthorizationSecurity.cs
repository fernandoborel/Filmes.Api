using Filmes.Domain.Interfaces.Security;
using Filmes.Domain.Models;
using Filmes.Infra.Security.Settings;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Filmes.Infra.Security.Services;

public class AuthorizationSecurity : IAuthorizationSecurity
{
    private readonly JwtSettings _jwtSettings;

    public AuthorizationSecurity(JwtSettings jwtSettings)
    {
        _jwtSettings = jwtSettings;
    }

    public string CreateToken(Usuario usuario)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, usuario.Nome),
                new Claim(ClaimTypes.Email, usuario.Email),
            }),

            Expires = DateTime.UtcNow.AddHours(_jwtSettings.ExpirationHours),

            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
