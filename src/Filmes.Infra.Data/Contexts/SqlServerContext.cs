using Filmes.Domain.Models;
using Filmes.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Filmes.Infra.Data.Contexts
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FilmeMap());

            modelBuilder.Entity<Filme>()
                .Property(f => f.Id)
                .UseIdentityColumn();
        }

        public DbSet<Filme> Filmes { get; set; }
    }
}
