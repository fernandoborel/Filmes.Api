using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Filmes.Application.Dtos;

public class CriarFilmeDto
{
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [Length(3,100, ErrorMessage = "Titulo deve conter entre {0} e {1} caracteres.")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [Length(3,5000, ErrorMessage = "Sinopse deve conter entre {0} e {1} caracteres.")]
    public string Sinopse { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [Length(3,100, ErrorMessage = "Genero deve conter entre {0} e {1} caracteres.")]
    public string Genero { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public int Duracao { get; set; }

    //[Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public IFormFile ImagemCapa { get; set; }

    // Lista de sessões associadas ao filme
    public List<CriarSessaoDto> Sessoes { get; set; }
}
