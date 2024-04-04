namespace Filmes.Domain.Models;

public class Endereco
{
    public int Id { get; set; }
    public string Logradouro { get; set; }
    public string Numero { get; set; }
    public virtual Cinema? Cinema { get; set; }
}
