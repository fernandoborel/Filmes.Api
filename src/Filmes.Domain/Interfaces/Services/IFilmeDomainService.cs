using Filmes.Domain.Models;

namespace Filmes.Domain.Interfaces.Services;

public interface IFilmeDomainService : IDisposable
{
    Task Adicionar(Filme filme);
    Task Atualizar(Filme filme);
    Task Remover(Filme filme);

    Task<IEnumerable<Filme>> ObterPorId(int id);
    Task<IEnumerable<Filme>> ObterTodos();
}
