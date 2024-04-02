using Filmes.Application.Dtos;
using Filmes.Domain.Models;

namespace Filmes.Application.Interfaces;

public interface ICinemaAppService : IDisposable
{
    Task Adicionar(CriarCinemaDto dto);
    Task Atualizar(AtualizarCinemaDto dto);
    Task Remover(int id);

    Task<Cinema> ObterPorId(int id);
    Task<IEnumerable<Cinema>> ObterTodos();
    Task<IEnumerable<Cinema>> ObterPorNome(string nome);
}
