using Filmes.Domain.Models;

namespace Filmes.Domain.Interfaces.Services;

public interface IEnderecoDomainService : IDisposable
{
    Task Adicionar(Endereco endereco);
    Task Atualizar(Endereco endereco);
    Task Remover(Endereco endereco);

    Task<Endereco> ObterPorId(int id);
    Task<IEnumerable<Endereco>> ObterTodos();
    Task<IEnumerable<Endereco>> ObterPorLogradouro(string logradouro);
}
