using Filmes.Application.Dtos;
using Filmes.Application.Interfaces;
using Filmes.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Filmes.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUsuarioAppService _usuarioAppService;

    public AuthController(IUsuarioAppService usuarioAppService)
    {
        _usuarioAppService = usuarioAppService;
    }

    [HttpPost("autenticar")]
    public async Task<IActionResult> Post(AutenticarUsuarioDto dto)
    {
        try
        {
            var usuario = await _usuarioAppService.AutenticarUsuarioAsync(dto);

            var response = new AutenticarUsuarioResponse
            {
                Message = "Usuário autenticado com sucesso!",
                Model = new AuthorizationModel
                {
                    IdUsuario = usuario.IdUsuario,
                    Nome = usuario.Nome,
                    Email = usuario.Email,
                    AccessToken = usuario.AccessToken,
                }
            };

            return Ok(response);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}
