namespace Filmes.Domain.Models;

public class AuthorizationModel
{
    public int IdUsuario { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string AccessToken { get; set; }
}
