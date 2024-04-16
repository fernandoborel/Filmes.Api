using Filmes.Application.Interfaces;
using Filmes.Application.Services;
using Filmes.Domain.Interfaces.Repositories;
using Filmes.Domain.Interfaces.Security;
using Filmes.Domain.Interfaces.Services;
using Filmes.Domain.Services;
using Filmes.Infra.Data.Contexts;
using Filmes.Infra.Data.Repositories;
using Filmes.Infra.Security.Services;
using Microsoft.EntityFrameworkCore;

namespace Filmes.Api.Extensions;

public class EntityFrameworkExtension
{
    public static void AddEntityFramework(WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("FilmesApi");

        builder.Services.AddDbContext<SqlServerContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        #region Interfaces Filmes

        builder.Services.AddTransient<IFilmeRepository, FilmeRepository>();
        builder.Services.AddTransient<IFilmeAppService, FilmeAppService>();
        builder.Services.AddTransient<IFilmeDomainService, FilmeDomainService>();

        #endregion

        #region Interfaces Cinemas

        builder.Services.AddTransient<ICinemaRepository, CinemaRepository>();
        builder.Services.AddTransient<ICinemaAppService, CinemaAppService>();
        builder.Services.AddTransient<ICinemaDomainService, CinemaDomainService>();

        #endregion

        #region Interfaces Usuarios

        builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
        builder.Services.AddTransient<IUsuarioAppService, UsuarioAppService>();
        builder.Services.AddTransient<IUsuarioDomainService, UsuarioDomainService>();

        #endregion

        builder.Services.AddTransient<IAuthorizationSecurity, AuthorizationSecurity>();
    }
}
