using Filmes.Application.Dtos;
using Filmes.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Filmes.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FilmesController : ControllerBase
{
    private readonly IFilmeAppService _filmeAppService;

    public FilmesController(IFilmeAppService filmeAppService)
    {
        _filmeAppService = filmeAppService;
    }

    [HttpGet("obter-filmes")]
    public async Task<IActionResult> ObterFilmes()
    {
        var filmes = await _filmeAppService.ObterTodos();
        return StatusCode(200, filmes);
    }

    [HttpGet("obter-filme/{id}")]
    public async Task<IActionResult> ObterFilme(int id)
    {
        var filme = await _filmeAppService.ObterPorId(id);
        return StatusCode(200, filme);
    }

    [HttpPost("adicionar-filme")]
    public async Task<IActionResult> AdicionarFilme(CriarFilmeDto dto)
    {
        await _filmeAppService.Adicionar(dto);
        return StatusCode(201, new { message = "Filme cadastrado com sucesso!", dto});
    }

    [HttpPut("atualizar-filme")]
    public async Task<IActionResult> AtualizarFilme(AtualizarFilmeDto dto)
    {
        await _filmeAppService.Atualizar(dto);
        return StatusCode(200, new { message = "Filme atualizado com sucesso!", dto });
    }

    [HttpDelete("remover-filme/{id}")]
    public async Task<IActionResult> RemoverFilme(int id)
    {
        await _filmeAppService.Remover(id);
        return StatusCode(200, new { message = "Filme removido com sucesso!" });
    }
}
