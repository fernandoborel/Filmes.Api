using Filmes.Domain.Models;

namespace Filmes.Domain.Interfaces.Services;

public interface IUsuarioDomainService : IDisposable
{
    Task<AuthorizationModel> AutenticarUsuarioAsync(string email, string senha);

    Task Adicionar(Usuario usuario);
    Task Atualizar(Usuario usuario);
    Task Remover(int id);

    Task<Usuario> ObterPorId(int id);
    Task<Usuario> ObterPorEmail(string email);

    Task<IEnumerable<Usuario>> ObterTodos();
}
