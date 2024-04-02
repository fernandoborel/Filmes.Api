using Filmes.Domain.Interfaces.Repositories;
using Filmes.Domain.Interfaces.Services;
using Filmes.Domain.Models;

namespace Filmes.Domain.Services;

public class EnderecoDomainService : IEnderecoDomainService
{
    private readonly IEnderecoRepository _enderecoRepository;

    public EnderecoDomainService(IEnderecoRepository enderecoRepository)
    {
        _enderecoRepository = enderecoRepository;
    }

    public async Task Adicionar(Endereco endereco)
    {
        await _enderecoRepository.AddAsync(endereco);
    }

    public async Task Atualizar(Endereco endereco)
    {
        var end = await _enderecoRepository.GetByIdAsync(endereco.Id);
        if (end != null)
        {
            end.Logradouro = endereco.Logradouro;
            end.Numero = endereco.Numero;

            await _enderecoRepository.UpdateAsync(end);
        }
    }

    public async Task Remover(Endereco endereco)
    {
        var end = await _enderecoRepository.GetByIdAsync(endereco.Id);
        if (end != null)
        {
            await _enderecoRepository.DeleteAsync(end);
        }
    }

    public void Dispose()
    {
        _enderecoRepository?.Dispose();
    }

    public async Task<Endereco> ObterPorId(int id)
    {
        var end = await _enderecoRepository.GetByIdAsync(id);
        return end;
    }

    public async Task<IEnumerable<Endereco>> ObterPorLogradouro(string logradouro)
    {
        var end = await _enderecoRepository.GetAddressAsync(logradouro);
        return end;
    }

    public async Task<IEnumerable<Endereco>> ObterTodos()
    {
        var ends = await _enderecoRepository.GetAllAsync();
        return ends;
    }
}
