using Filmes.Application.Dtos;
using Filmes.Domain.Models;

namespace Filmes.Application.Interfaces;

public interface IUsuarioAppService : IDisposable
{
    Task Adicionar(CriarUsuarioDto dto);
    Task Alterar(AlterarUsuarioDto dto);
    Task Remover(int id);

    Task<Usuario> ObterPorId(int id);
    Task<Usuario> ObterPorEmail(string email);
    Task<IEnumerable<Usuario>> ObterTodos();

    Task<AuthorizationModel> AutenticarUsuarioAsync(AutenticarUsuarioDto dto);
}
