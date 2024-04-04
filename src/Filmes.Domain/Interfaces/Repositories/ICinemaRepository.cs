using Filmes.Domain.Models;

namespace Filmes.Domain.Interfaces.Repositories;

public interface ICinemaRepository : IBaseRepository<Cinema>
{
    Task<IEnumerable<Cinema>> GetByCineAsync(string cine);
    Task AdicionarEndereco(Endereco endereco);
    Task AdicionarCinema(Cinema cinema);
    Task AdicionarSessao(Sessao sessao);
}
