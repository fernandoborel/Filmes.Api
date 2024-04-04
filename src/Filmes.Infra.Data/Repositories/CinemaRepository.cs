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

    public override async Task<Cinema> GetByIdAsync(int id)
    {
        return await _context.Cinemas
                             .Include(c => c.Endereco)
                             .Include(c => c.Sessoes)
                                .ThenInclude(s => s.Filme)
                             .FirstOrDefaultAsync(c => c.Id == id);
    }

    public override async Task<IEnumerable<Cinema>> GetAllAsync()
    {
        return await _context.Cinemas
                             .Include(c => c.Endereco)
                             .Select(c => new Cinema
                             {
                                 Id = c.Id,
                                 Nome = c.Nome,
                                 EnderecoId = c.EnderecoId,
                                 Endereco = c.Endereco
                             })
                             .ToListAsync();
    }

    public async Task<IEnumerable<Cinema>> GetByCineAsync(string cine)
    {
        return await _context.Cinemas
                             .Include(c => c.Endereco)
                             .Where(c => c.Nome.Contains(cine))
                             .ToListAsync();
    }

    public async Task AdicionarEndereco(Endereco endereco)
    {
        _context.Enderecos.Add(endereco);
    }

    public async Task AdicionarCinema(Cinema cinema)
    {
        _context.Cinemas.Add(cinema);
    }

    public async Task AdicionarSessao(Sessao sessao)
    {
        _context.Sessoes.Add(sessao);
    }
}
