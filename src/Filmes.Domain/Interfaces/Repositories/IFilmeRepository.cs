using Filmes.Domain.Models;

namespace Filmes.Domain.Interfaces.Repositories;

public interface IFilmeRepository : IBaseRepository<Filme>
{
    Task<IEnumerable<Filme>> GetByTitleAsync(string title);
}
