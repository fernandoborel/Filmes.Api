using Filmes.Domain.Interfaces.Repositories;
using Filmes.Domain.Models;
using Filmes.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Filmes.Infra.Data.Repositories;

public class EnderecoRepository : BaseRepository<Endereco>, IEnderecoRepository
{
    private readonly SqlServerContext _context;

    public EnderecoRepository(SqlServerContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Endereco>> GetAddressAsync(string adr)
    {
        var enderecoExistente = await _context.Enderecos.Where(e => e.Logradouro == adr).ToListAsync();
        return enderecoExistente;
    }
}

