using Filmes.Domain.Models;

namespace Filmes.Application.Dtos;

public class AutenticarUsuarioResponse
{
    public string Message { get; set; }
    public AuthorizationModel Model { get; set; }
}
