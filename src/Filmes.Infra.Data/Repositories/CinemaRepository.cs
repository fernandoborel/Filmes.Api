using Filmes.Domain.Interfaces.Repositories;
using Filmes.Domain.Models;
using Filmes.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Filmes.Infra.Data.Repositories;

public class CinemaRepository : BaseRepository<Cinema>, ICinemaRepository
{
    private readonly SqlServerContext _context;

    public CinemaRepository(SqlServerContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Cinema>> GetByCineAsync(string cine)
    {
        var cinemaExistente = await _context.Cinemas.Where(c => c.Nome == cine).ToListAsync();
        return cinemaExistente;
    }
}