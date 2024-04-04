using System.ComponentModel.DataAnnotations;

namespace Filmes.Application.Dtos;

public class CriarCinemaDto
{
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [Length(3, 100, ErrorMessage = "Nome deve conter entre {0} e {1} caracteres.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public string Logradouro { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public string Numero { get; set; }
}
