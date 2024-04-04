namespace Filmes.Domain.Models;

public class Cinema
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int? EnderecoId { get; set; }
    public virtual Endereco? Endereco { get; set; }
    public virtual ICollection<Sessao>? Sessoes { get; set; }
}
