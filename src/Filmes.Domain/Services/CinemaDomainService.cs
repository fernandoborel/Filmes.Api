using Filmes.Domain.Interfaces.Repositories;
using Filmes.Domain.Interfaces.Services;
using Filmes.Domain.Models;

namespace Filmes.Domain.Services;

public class CinemaDomainService : ICinemaDomainService
{
    private readonly ICinemaRepository _cinemaRepository;

    public CinemaDomainService(ICinemaRepository cinemaRepository)
    {
        _cinemaRepository = cinemaRepository;
    }

    public async Task Adicionar(Cinema cinema)
    {
        await _cinemaRepository.AddAsync(cinema);
    }

    public async Task Atualizar(Cinema cinema)
    {
        var cinemaExistente = await _cinemaRepository.GetByIdAsync(cinema.Id);
        if (cinemaExistente != null)
        {
            cinemaExistente.Nome = cinema.Nome;
            cinemaExistente.Endereco = cinema.Endereco;
            cinemaExistente.Endereco.Logradouro = cinema.Endereco.Logradouro;
            cinemaExistente.Endereco.Numero = cinema.Endereco.Numero;

            await _cinemaRepository.UpdateAsync(cinemaExistente);
        }
    }

    public async Task Remover(Cinema cinema)
    {
        var cinemaExistente = await _cinemaRepository.GetByIdAsync(cinema.Id);
        if (cinemaExistente != null)
        {
            await _cinemaRepository.DeleteAsync(cinemaExistente);
        }
    }


    public void Dispose()
    {
        _cinemaRepository?.Dispose();
    }

    public async Task<Cinema> ObterPorId(int id)
    {
        var cinemaExistente = await _cinemaRepository.GetByIdAsync(id);
        return cinemaExistente;
    }

    public async Task<IEnumerable<Cinema>> ObterPorNome(string nome)
    {
        var cinemaExistente = await _cinemaRepository.GetByCineAsync(nome);
        return cinemaExistente;
    }

    public async Task<IEnumerable<Cinema>> ObterTodos()
    {
        var cinemas = await _cinemaRepository.GetAllAsync();
        return cinemas;
    }
}
