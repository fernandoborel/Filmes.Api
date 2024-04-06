using Filmes.Domain.Models;

namespace Filmes.Domain.Interfaces.Repositories;

public interface ISessaoRepository : IBaseRepository<Sessao>
{
    Task<IEnumerable<Sessao>> GetBySessaoAsync(string sessao);
}
