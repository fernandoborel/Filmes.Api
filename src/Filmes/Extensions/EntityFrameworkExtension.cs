﻿using Filmes.Application.Interfaces;
using Filmes.Application.Services;
using Filmes.Domain.Interfaces.Repositories;
using Filmes.Domain.Interfaces.Services;
using Filmes.Domain.Services;
using Filmes.Infra.Data.Contexts;
using Filmes.Infra.Data.Repositories;
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

        builder.Services.AddScoped<IFilmeRepository, FilmeRepository>();
        builder.Services.AddScoped<IFilmeAppService, FilmeAppService>();
        builder.Services.AddScoped<IFilmeDomainService, FilmeDomainService>();

        #endregion

        #region Interfaces Cinemas

        builder.Services.AddScoped<ICinemaRepository, CinemaRepository>();
        builder.Services.AddScoped<ICinemaAppService, CinemaAppService>();
        builder.Services.AddScoped<ICinemaDomainService, CinemaDomainService>();

        #endregion
    }
}
