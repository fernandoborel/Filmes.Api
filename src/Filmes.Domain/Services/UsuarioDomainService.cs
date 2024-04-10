using Filmes.Domain.Interfaces.Repositories;
using Filmes.Domain.Interfaces.Security;
using Filmes.Domain.Interfaces.Services;
using Filmes.Domain.Models;

namespace Filmes.Domain.Services;

public class UsuarioDomainService : IUsuarioDomainService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IAuthorizationSecurity _authorizationSecurity;

    public UsuarioDomainService(IUsuarioRepository usuarioRepository, 
        IAuthorizationSecurity authorizationSecurity)
    {
        _usuarioRepository = usuarioRepository;
        _authorizationSecurity = authorizationSecurity;
    }

    public async Task Adicionar(Usuario usuario)
    {
        await _usuarioRepository.AddAsync(usuario);
    }

    public async Task Atualizar(Usuario usuario)
    {
        await _usuarioRepository.UpdateAsync(usuario);
    }

    public async Task Remover(int id)
    {
        var user = await _usuarioRepository.GetByIdAsync(id);
        await _usuarioRepository.DeleteAsync(user);
    }

    public void Dispose()
    {
        _usuarioRepository.Dispose();
    }

    public async Task<Usuario> ObterPorEmail(string email)
    {
        var user = await _usuarioRepository.Get(email);
        return user;
    }

    public async Task<Usuario> ObterPorId(int id)
    {
        var user = await _usuarioRepository.GetByIdAsync(id);
        return user;
    }

    public async Task<IEnumerable<Usuario>> ObterTodos()
    {
        return await _usuarioRepository.GetAllAsync();  
    }

    public async Task<AuthorizationModel> AutenticarUsuarioAsync(string email, string senha)
    {
        var user = await _usuarioRepository.Get(email, senha);

        if (user != null)
            return new AuthorizationModel
            {
                IdUsuario = user.IdUsuario,
                Email = user.Email,
                AccessToken = _authorizationSecurity.CreateToken(user)
            };

        throw new Exception("Usuário ou senha inválidos");
    }
}
