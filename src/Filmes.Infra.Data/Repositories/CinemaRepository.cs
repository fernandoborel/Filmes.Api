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
                             .Include(c => c.Endereco) // Carregar explicitamente a propriedade endereco
                             .FirstOrDefaultAsync(c => c.Id == id);
    }

    public override async Task<IEnumerable<Cinema>> GetAllAsync()
    {
        return await _context.Cinemas
                             .Include(c => c.Endereco) // Carregar explicitamente a propriedade endereco
                             .ToListAsync();
    }

    public async Task<IEnumerable<Cinema>> GetByCineAsync(string cine)
    {
        return await _context.Cinemas
                             .Include(c => c.Endereco) // Carregar explicitamente a propriedade endereco
                             .Where(c => c.Nome == cine)
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
}
