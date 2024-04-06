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

    public async Task<IEnumerable<Sessao>> GetBySessaoAsync(string sessao)
    {
        return await _context.Sessoes
                             .Include(s => s.Cinema)
                             .Include(s => s.Filme)
                             .Where(s => s.Horario.ToString().Contains(sessao))
                             .ToListAsync();
    }
}
