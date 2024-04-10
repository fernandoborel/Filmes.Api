using System.ComponentModel.DataAnnotations;

namespace Filmes.Application.Dtos;

public class AutenticarUsuarioDto
{
    [Required(ErrorMessage = "Informe o login.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Informe a senha.")]
    public string Senha { get; set; }
}
