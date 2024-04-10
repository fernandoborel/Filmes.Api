using Filmes.Application.Dtos;
using Filmes.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Filmes.Api.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CinemasController : ControllerBase
{
    private readonly ICinemaAppService _cineAppService;

    public CinemasController(ICinemaAppService cineAppService)
    {
        _cineAppService = cineAppService;
    }

    [HttpGet("obter-cines")]
    public async Task<IActionResult> ObterCines()
    {
        var cines = await _cineAppService.ObterTodos();
        return StatusCode(200, cines);
    }

    [HttpGet("obter-cine/{id}")]
    public async Task<IActionResult> ObterCine(int id)
    {
        var cine = await _cineAppService.ObterPorId(id);
        return StatusCode(200, cine);
    }

    [HttpGet("obter-cine-nome/{nome}")]
    public async Task<IActionResult> ObterCineNome(string nome)
    {
        var cine = await _cineAppService.ObterPorNome(nome);
        return StatusCode(200, cine);
    }

    [HttpPost("adicionar-cine")]
    public async Task<IActionResult> AdicionarCine(CriarCinemaDto dto)
    {
        await _cineAppService.Adicionar(dto);
        return StatusCode(201, new { message = "Cinema cadastrado com sucesso!", dto});
    }

    [HttpPut("atualizar-cine")]
    public async Task<IActionResult> AtualizarCine(AtualizarCinemaDto dto)
    {
        await _cineAppService.Atualizar(dto);
        return StatusCode(200, new { message = "Cinema atualizado com sucesso!", dto });
    }

    [HttpDelete("remover-cine/{id}")]
    public async Task<IActionResult> RemoverCine(int id)
    {
        await _cineAppService.Remover(id);
        return StatusCode(200, new { message = "Cinema removido com sucesso!" });
    }
}
