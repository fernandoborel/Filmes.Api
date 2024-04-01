using Filmes.Domain.Models;

namespace Filmes.Domain.Interfaces.Repositories;

public interface ISessaoRepository : IBaseRepository<Sessao>
{
    Task<IEnumerable<Sessao>> GetByMovieAsync(int filmeId);
    Task<IEnumerable<Sessao>> GetByCineAsync(int cinemaId);
}
