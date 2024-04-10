using System.ComponentModel.DataAnnotations;

namespace Filmes.Application.Dtos;

public class CriarUsuarioDto
{
    [Required(ErrorMessage = "O campo Nome é obrigatório.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O campo Email é obrigatório.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo Senha é obrigatório.")]
    public string Senha { get; set; }
}
