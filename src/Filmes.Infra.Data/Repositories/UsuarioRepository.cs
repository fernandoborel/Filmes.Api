using Filmes.Domain.Interfaces.Repositories;
using Filmes.Domain.Models;
using Filmes.Infra.Data.Contexts;
using Filmes.Infra.Data.Utils;
using Microsoft.EntityFrameworkCore;

namespace Filmes.Infra.Data.Repositories;

public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
{
    private readonly SqlServerContext _context;

    public UsuarioRepository(SqlServerContext context) : base(context)
    {
        _context = context;
    }

    public async Task AddAsync(Usuario usuario)
    {
        usuario.Senha = MD5Util.Get(usuario.Senha);
        await base.AddAsync(usuario);
    }

    public async Task UpdateAsync(Usuario usuario)
    {
        usuario.Senha = MD5Util.Get(usuario.Senha);
        await base.UpdateAsync(usuario);
    }

    public async Task<Usuario> Get(string email)
    {
        return await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<Usuario> Get(string email, string senha)
    {
        senha = MD5Util.Get(senha);

        return await _context.Usuarios
            .FirstOrDefaultAsync(u => u.Email.Equals(email) && u.Senha.Equals(senha));
    }
}
