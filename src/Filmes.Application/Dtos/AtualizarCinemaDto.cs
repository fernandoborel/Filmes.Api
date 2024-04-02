using System.ComponentModel.DataAnnotations;

namespace Filmes.Application.Dtos;

public class AtualizarCinemaDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [Length(3,100, ErrorMessage = "Nome deve conter entre {0} e {1} caracteres.")]
    public string Nome { get; set; }
}
