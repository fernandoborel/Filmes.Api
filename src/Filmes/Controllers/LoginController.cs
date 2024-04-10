using Filmes.Application.Dtos;
using Filmes.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Filmes.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly IUsuarioAppService _usuarioAppService;

    public LoginController(IUsuarioAppService usuarioAppService)
    {
        _usuarioAppService = usuarioAppService;
    }

    [HttpPost("cadastrar")]
    public async Task<IActionResult> Post(CriarUsuarioDto dto)
    {
        await _usuarioAppService.Adicionar(dto);
        return StatusCode(201, new { message = "Usuário cadastrado com sucesso!"});
    }

    [HttpPut("alterar")]
    public async Task<IActionResult> Put(AlterarUsuarioDto dto)
    {
        await _usuarioAppService.Alterar(dto);
        return StatusCode(200, new { message = "Usuário alterado com sucesso!"});
    }

    [HttpDelete("remover/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _usuarioAppService.Remover(id);
        return StatusCode(200, new { message = "Usuário removido com sucesso!"});
    }

    [HttpGet("obter-usuario/{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var usuario = await _usuarioAppService.ObterPorId(id);
        return StatusCode(200, usuario);
    }
}
