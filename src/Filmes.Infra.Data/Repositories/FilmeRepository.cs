using Filmes.Domain.Interfaces.Repositories;
using Filmes.Domain.Models;
using Filmes.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Filmes.Infra.Data.Repositories;

public class FilmeRepository : BaseRepository<Filme>, IFilmeRepository
{
    private readonly SqlServerContext _context;

    public FilmeRepository(SqlServerContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Filme>> GetByTitleAsync(string title)
    {
        return await _context.Filmes.Where(f => f.Titulo.Contains(title)).ToListAsync();
    }
}

