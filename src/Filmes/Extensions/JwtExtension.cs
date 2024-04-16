using Filmes.Domain.Interfaces.Security;
using Filmes.Infra.Security.Services;
using Filmes.Infra.Security.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Filmes.Api.Extensions;

public class JwtExtension
{
    public static void AddJwtBearerSecurity(WebApplicationBuilder builder)
    {
        builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
        builder.Services.AddTransient<IAuthorizationSecurity, AuthorizationSecurity>();

        builder.Services.AddAuthentication(
            auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }
            ).AddJwtBearer(
            bearer =>
            {
                bearer.RequireHttpsMetadata = false;
                bearer.SaveToken = true;
                bearer.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.ASCII.GetBytes
                        (builder.Configuration
                        .GetSection("JwtSettings")
                        .GetSection("SecretKey").Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
    }
}
