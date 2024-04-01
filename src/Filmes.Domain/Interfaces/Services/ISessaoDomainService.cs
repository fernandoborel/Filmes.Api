using Filmes.Domain.Models;

namespace Filmes.Domain.Interfaces.Services;

public interface ISessaoDomainService : IDisposable
{
    Task Adicionar(Sessao sessao);
    Task Atualizar(Sessao sessao);
    Task Remover(Sessao sessao);

    Task<Sessao> ObterPorId(int id);
    Task<IEnumerable<Sessao>> ObterTodos();
    Task<IEnumerable<Sessao>> ObterPorFilme(int filmeId);
    Task<IEnumerable<Sessao>> ObterPorCinema(int cinemaId);
}
