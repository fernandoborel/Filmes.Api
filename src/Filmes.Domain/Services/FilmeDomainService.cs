using Filmes.Domain.Interfaces.Repositories;
using Filmes.Domain.Interfaces.Services;
using Filmes.Domain.Models;

namespace Filmes.Domain.Services;

public class FilmeDomainService : IFilmeDomainService
{
    private readonly IFilmeRepository _filmeRepository;

    public FilmeDomainService(IFilmeRepository filmeRepository)
    {
        _filmeRepository = filmeRepository;
    }

    public async Task Adicionar(Filme filme)
    {
        await _filmeRepository.AddAsync(filme);
    }

    public async Task Atualizar(Filme filme)
    {
        var filmeExistente = await _filmeRepository.GetByIdAsync(filme.Id);

        if(filmeExistente != null)
        {
            filmeExistente.Titulo = filme.Titulo;
            filmeExistente.Sinopse = filme.Sinopse;
            filmeExistente.Genero = filme.Genero;
            filmeExistente.Duracao = filme.Duracao;
            filmeExistente.ImagemCapa = filme.ImagemCapa;

            await _filmeRepository.UpdateAsync(filmeExistente);
        }
    }

    public async Task Remover(Filme filme)
    {
        var filmeExistente = await _filmeRepository.GetByIdAsync(filme.Id);
        await _filmeRepository.DeleteAsync(filmeExistente);
    }

    public void Dispose()
    {
        _filmeRepository?.Dispose();
    }

    public async Task<Filme> ObterPorId(int id)
    {
        var filme = await _filmeRepository.GetByIdAsync(id);
        return filme;
    }

    public async Task<IEnumerable<Filme>> ObterPorTitulo(string titulo)
    {
        var filme = await _filmeRepository.GetByTitleAsync(titulo);
        return filme;
    }

    public async Task<IEnumerable<Filme>> ObterTodos()
    {
        var filmes = await _filmeRepository.GetAllAsync();
        return filmes;
    }
}
