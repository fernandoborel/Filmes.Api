using Filmes.Application.Dtos;
using Filmes.Application.Interfaces;
using Filmes.Domain.Interfaces.Services;
using Filmes.Domain.Models;

namespace Filmes.Application.Services;

public class FilmeAppService : IFilmeAppService
{

    private readonly IFilmeDomainService _filmeDomainService;

    public FilmeAppService(IFilmeDomainService filmeDomainService)
    {
        _filmeDomainService = filmeDomainService;
    }

    public async Task Adicionar(CriarFilmeDto dto)
    {
        var foto = dto.ImagemCapa?.OpenReadStream();

        var filme = new Filme
        {
            Titulo = dto.Titulo,
            Sinopse = dto.Sinopse,
            Genero = dto.Genero,
            Duracao = dto.Duracao,
            ImagemCapa = LerFotoComoArrayDeBytes(foto),
        };

        await _filmeDomainService.Adicionar(filme);
    }

    public async Task Atualizar(AtualizarFilmeDto dto)
    {
        var filme = await _filmeDomainService.ObterPorId(dto.Id);

        if (filme != null)
        {
            var foto = dto.ImagemCapa?.OpenReadStream();

            filme.Titulo = dto.Titulo;
            filme.Sinopse = dto.Sinopse;
            filme.Genero = dto.Genero;
            filme.Duracao = dto.Duracao;
            filme.ImagemCapa = LerFotoComoArrayDeBytes(foto);

            await _filmeDomainService.Atualizar(filme);
        }
    }

    public async Task Remover(int id)
    {
        var filme = await _filmeDomainService.ObterPorId(id);
        if (filme != null)
        {
            await _filmeDomainService.Remover(filme);
        }
    }

    public void Dispose()
    {
        _filmeDomainService.Dispose();
    }

    public async Task<Filme> ObterPorId(int id)
    {
        var filme = await _filmeDomainService.ObterPorId(id);
        return filme;
    }

    public async Task<IEnumerable<Filme>> ObterPorTitulo(string titulo)
    {
        var filme = await _filmeDomainService.ObterPorTitulo(titulo);
        return filme;
    }

    public async Task<IEnumerable<Filme>> ObterTodos()
    {
        var filmes = await _filmeDomainService.ObterTodos();
        return filmes;
    }

    private byte[] LerFotoComoArrayDeBytes(Stream fotoStream)
    {
        using (var memoryStream = new MemoryStream())
        {
            fotoStream?.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }
    }
}
