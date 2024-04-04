using Filmes.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Filmes.Infra.Data.Mappings;

public class SessaoMap : IEntityTypeConfiguration<Sessao>
{
    public void Configure(EntityTypeBuilder<Sessao> builder)
    {
        builder.ToTable("Sessoes");

        builder.HasKey(s => s.Id);

        // Relacionamento com Filme
        builder.HasOne(s => s.Filme)
               .WithMany(f => f.Sessoes)
               .HasForeignKey(s => s.FilmeId)
               .OnDelete(DeleteBehavior.Cascade);

        // Relacionamento com Cinema
        builder.HasOne(s => s.Cinema)
               .WithMany(c => c.Sessoes)
               .HasForeignKey(s => s.CinemaId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.Property(s => s.Horario)
               .IsRequired();
    }
}
