using Filmes.Domain.Models;

namespace Filmes.Domain.Interfaces.Repositories;

public interface IUsuarioRepository : IBaseRepository<Usuario>
{
    Task<Usuario> Get(string email);
    Task<Usuario> Get(string email, string senha);
}
