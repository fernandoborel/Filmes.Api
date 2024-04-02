using Filmes.Domain.Interfaces.Repositories;
using Filmes.Domain.Interfaces.Services;
using Filmes.Domain.Models;

namespace Filmes.Domain.Services;

public class SessaoDomainService : ISessaoDomainService
{
    private readonly ISessaoRepository _sessaoRepository;

    public SessaoDomainService(ISessaoRepository sessaoRepository)
    {
        _sessaoRepository = sessaoRepository;
    }

    public async Task Adicionar(Sessao sessao)
    {
        await _sessaoRepository.AddAsync(sessao);
    }

    public async Task Atualizar(Sessao sessao)
    {
        var ses = await _sessaoRepository.GetByIdAsync(sessao.FilmeId);
        if(ses != null)
        {
            ses.Cinema = sessao.Cinema;
            ses.Filme = sessao.Filme;

            await _sessaoRepository.UpdateAsync(ses);
        }
    }

    public async Task Remover(Sessao sessao)
    {
        var ses = await _sessaoRepository.GetByIdAsync(sessao.FilmeId);
        if(ses != null)
        {
            await _sessaoRepository.DeleteAsync(ses);
        }
    }

    public void Dispose()
    {
        _sessaoRepository?.Dispose();
    }

    public async Task<IEnumerable<Sessao>> ObterPorCinema(int cinemaId)
    {
        var ses = await _sessaoRepository.GetByCineAsync(cinemaId);
        return ses;
    }

    public async Task<IEnumerable<Sessao>> ObterPorFilme(int filmeId)
    {
        var ses = await _sessaoRepository.GetByCineAsync(filmeId);
        return ses;
    }

    public async Task<Sessao> ObterPorId(int id)
    {
        var ses = await _sessaoRepository.GetByIdAsync(id);
        return ses;
    }

    public async Task<IEnumerable<Sessao>> ObterTodos()
    {
        var ses = await _sessaoRepository.GetAllAsync();
        return ses;
    }
}
