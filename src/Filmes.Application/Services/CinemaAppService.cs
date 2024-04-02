using Filmes.Application.Dtos;
using Filmes.Application.Interfaces;
using Filmes.Domain.Interfaces.Services;
using Filmes.Domain.Models;

namespace Filmes.Application.Services;

public class CinemaAppService : ICinemaAppService
{
    private readonly ICinemaDomainService _cinemaDomainService;

    public CinemaAppService(ICinemaDomainService cinemaDomainService)
    {
        _cinemaDomainService = cinemaDomainService;
    }

    public async Task Adicionar(CriarCinemaDto dto)
    {
        var cine = new Cinema
        {
            Nome = dto.Nome,
        };

        await _cinemaDomainService.Adicionar(cine);
    }

    public async Task Atualizar(AtualizarCinemaDto dto)
    {
        var cine = await _cinemaDomainService.ObterPorId(dto.Id);
        if(cine != null)
        {
            cine.Nome = dto.Nome;
            await _cinemaDomainService.Atualizar(cine);
        }
    }

    public async Task Remover(int id)
    {
        var cine = await _cinemaDomainService.ObterPorId(id);
        if(cine != null)
        {
            await _cinemaDomainService.Remover(cine);
        }
    }

    public void Dispose()
    {
        _cinemaDomainService.Dispose();
    }

    public async Task<Cinema> ObterPorId(int id)
    {
        var cine = await _cinemaDomainService.ObterPorId(id);
        return cine;
    }

    public async Task<IEnumerable<Cinema>> ObterPorNome(string nome)
    {
        var cine = await _cinemaDomainService.ObterPorNome(nome);
        return cine;
    }

    public async Task<IEnumerable<Cinema>> ObterTodos()
    {
        var cines = await _cinemaDomainService.ObterTodos();
        return cines;
    }
}
