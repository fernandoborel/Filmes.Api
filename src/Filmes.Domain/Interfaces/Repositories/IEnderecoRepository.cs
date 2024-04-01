using Filmes.Domain.Models;

namespace Filmes.Domain.Interfaces.Repositories;

public interface IEnderecoRepository : IBaseRepository<Endereco>
{
    Task<IEnumerable<Endereco>> GetAddressAsync(string adr);
}
