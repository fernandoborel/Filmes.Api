using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Filmes.Application.Dtos;

public class AtualizarFilmeDto
{
    public int Id { get; set; }

    [Length(3, 100, ErrorMessage = "Titulo deve conter entre {0} e {1} caracteres.")]
    public string Titulo { get; set; }

    [Length(3, 1000, ErrorMessage = "Sinopse deve conter entre {0} e {1} caracteres.")]
    public string Sinopse { get; set; }

    [Length(3, 100, ErrorMessage = "Genero deve conter entre {0} e {1} caracteres.")]
    public string Genero { get; set; }

    public int Duracao { get; set; }

    public IFormFile ImagemCapa { get; set; }
}
