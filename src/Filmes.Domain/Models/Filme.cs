namespace Filmes.Domain.Models;

public class Filme
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Sinopse { get; set; }
    public string Genero { get; set; }
    public int Duracao { get; set; }
    public byte[] ImagemCapa { get; set; }

    public virtual ICollection<Sessao> Sessoes { get; set; }
}
