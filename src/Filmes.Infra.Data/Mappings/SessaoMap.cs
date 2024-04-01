using Filmes.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Filmes.Infra.Data.Mappings;

public class SessaoMap : IEntityTypeConfiguration<Sessao>
{
    public void Configure(EntityTypeBuilder<Sessao> builder)
    {
        builder.ToTable("Sessoes");

        builder.HasKey(s => new { s.FilmeId, s.CinemaId });

        // Relacionamento com Filme
        builder.HasOne(s => s.Filme)
            .WithMany(f => f.Sessoes)
            .HasForeignKey(s => s.FilmeId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        // Relacionamento com Cinema
        builder.HasOne(s => s.Cinema)
            .WithMany(c => c.Sessoes)
            .HasForeignKey(s => s.CinemaId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}
