using Filmes.Domain.Models;

namespace Filmes.Domain.Interfaces.Services;

public interface ICinemaDomainService : IDisposable
{
    Task Adicionar(Cinema cinema);
    Task Atualizar(Cinema cinema);
    Task Remover(Cinema cinema);

    Task<Cinema> ObterPorId(int id);
    Task<IEnumerable<Cinema>> ObterTodos();
    Task<IEnumerable<Cinema>> ObterPorNome(string nome);
}
