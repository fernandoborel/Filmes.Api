namespace Filmes.Domain.Models;

public class Sessao
{
    public int Id { get; set; }
    public int FilmeId { get; set; }
    public Filme Filme { get; set; }
    public int CinemaId { get; set; }
    public Cinema Cinema { get; set; }
    public DateTime Horario { get; set; } = DateTime.Now;
}
