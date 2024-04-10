using Filmes.Application.Dtos;
using Filmes.Application.Interfaces;
using Filmes.Domain.Interfaces.Services;
using Filmes.Domain.Models;

namespace Filmes.Application.Services;

public class UsuarioAppService : IUsuarioAppService
{
    private readonly IUsuarioDomainService _usuarioDomainService;

    public UsuarioAppService(IUsuarioDomainService usuarioDomainService)
    {
        _usuarioDomainService = usuarioDomainService;
    }

    public async Task Adicionar(CriarUsuarioDto dto)
    {
        var login = await _usuarioDomainService.ObterPorEmail(dto.Email);
        if(login != null)
        {
            throw new Exception("Já existe um usuário cadastrado com este e-mail.");
        }

        var usuario = new Usuario
        {
            Nome = dto.Nome,
            Email = dto.Email,
            Senha = dto.Senha
        };

        await _usuarioDomainService.Adicionar(usuario);
    }

    public async Task Alterar(AlterarUsuarioDto dto)
    {
        var usuario = await _usuarioDomainService.ObterPorId(dto.IdUsuario);

        if(usuario != null)
        {
            usuario.Nome = dto.Nome;
            usuario.Email = dto.Email;
            usuario.Senha = dto.Senha;

            await _usuarioDomainService.Atualizar(usuario);
        }
    }

    public async Task Remover(int id)
    {
        var usuario = await _usuarioDomainService.ObterPorId(id);
        if(usuario != null)
        {
            await _usuarioDomainService.Remover(id);
        }
    }

    public async Task<AuthorizationModel> AutenticarUsuarioAsync(AutenticarUsuarioDto dto)
    {
        return await _usuarioDomainService.AutenticarUsuarioAsync(dto.Email, dto.Senha);
    }

    public void Dispose()
    {
        _usuarioDomainService.Dispose();
    }

    public async Task<Usuario> ObterPorEmail(string email)
    {
        var mail = await _usuarioDomainService.ObterPorEmail(email);
        return mail;
    }

    public async Task<Usuario> ObterPorId(int id)
    {
        var usuario = await _usuarioDomainService.ObterPorId(id);
        return usuario;
    }

    public async Task<IEnumerable<Usuario>> ObterTodos()
    {
        return await _usuarioDomainService.ObterTodos();
    }  
}
