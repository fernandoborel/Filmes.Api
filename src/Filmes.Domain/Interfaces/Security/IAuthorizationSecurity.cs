using Filmes.Domain.Models;

namespace Filmes.Domain.Interfaces.Security;

public interface IAuthorizationSecurity
{
    string CreateToken(Usuario usuario);
}
