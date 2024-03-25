using Filmes.Application.Dtos;
using Filmes.Domain.Models;

namespace Filmes.Application.Interfaces;

public interface IFilmeAppService : IDisposable
{
    Task Adicionar(CriarFilmeDto dto);
    Task Atualizar(AtualizarFilmeDto dto);
    Task Remover(int id);

    Task<Filme> ObterPorId(int id);
    Task<IEnumerable<Filme>> ObterTodos();
    Task<IEnumerable<Filme>> ObterPorTitulo(string titulo);
}
