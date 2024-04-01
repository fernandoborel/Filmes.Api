using Filmes.Domain.Models;
using Filmes.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Filmes.Infra.Data.Contexts;

public class SqlServerContext : DbContext
{
    public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new FilmeMap());
        modelBuilder.ApplyConfiguration(new CinemaMap());
        modelBuilder.ApplyConfiguration(new EnderecoMap());
        modelBuilder.ApplyConfiguration(new SessaoMap());

        modelBuilder.Entity<Filme>()
            .Property(f => f.Id)
            .UseIdentityColumn();
    }

    public DbSet<Filme> Filmes { get; set; }
    public DbSet<Cinema> Cinemas { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Sessao> Sessoes { get; set; }
}
