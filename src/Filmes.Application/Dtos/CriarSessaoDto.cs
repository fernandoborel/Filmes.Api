using System.ComponentModel.DataAnnotations;

namespace Filmes.Application.Dtos;

public class CriarSessaoDto
{
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public int CinemaId { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public DateTime Horario { get; set; }
}
