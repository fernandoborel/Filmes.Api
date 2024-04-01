using Filmes.Domain.Interfaces.Repositories;
using Filmes.Domain.Models;
using Filmes.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Filmes.Infra.Data.Repositories;

public class SessaoRepository : BaseRepository<Sessao>, ISessaoRepository
{
    private readonly SqlServerContext _context;

    public SessaoRepository(SqlServerContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Sessao>> GetByCineAsync(int cinemaId)
    {
        var sessoes = await _context.Sessoes
            .Include(s => s.Filme)
            .Include(s => s.Cinema)
            .Where(s => s.CinemaId == cinemaId)
            .ToListAsync();

        return sessoes;
    }

    public async Task<IEnumerable<Sessao>> GetByMovieAsync(int filmeId)
    {
        var sessoes = await _context.Sessoes
            .Include(s => s.Filme)
            .Include(s => s.Cinema)
            .Where(s => s.FilmeId == filmeId)
            .ToListAsync();

        return sessoes;
    }
}
