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
        var ses = await _sessaoRepository.GetByIdAsync(sessao.Id);
        if (ses != null)
        {
            ses.FilmeId = sessao.FilmeId;
            ses.CinemaId = sessao.CinemaId;
            ses.Filme = sessao.Filme;
            ses.Cinema = sessao.Cinema;
            ses.Horario = sessao.Horario;

            await _sessaoRepository.UpdateAsync(ses);
        }
    }

    public async Task Remover(Sessao sessao)
    {
        var ses = await _sessaoRepository.GetByIdAsync(sessao.Id);
        if (ses != null)
        {
            await _sessaoRepository.DeleteAsync(ses);
        }
    }

    public void Dispose()
    {
        _sessaoRepository?.Dispose();
    }

    public Task<Sessao> ObterPorId(int id)
    {
        var ses = _sessaoRepository.GetByIdAsync(id);
        return ses;
    }

    public async Task<IEnumerable<Sessao>> ObterSessao(string sessao)
    {
        return await _sessaoRepository.GetBySessaoAsync(sessao);
    }

    public async Task<IEnumerable<Sessao>> ObterTodos()
    {
        var sessoes = await _sessaoRepository.GetAllAsync();
        return sessoes;
    }    
}
