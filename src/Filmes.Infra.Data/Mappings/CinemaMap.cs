using Filmes.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Filmes.Infra.Data.Mappings;

public class CinemaMap : IEntityTypeConfiguration<Cinema>
{
    public void Configure(EntityTypeBuilder<Cinema> builder)
    {
        builder.ToTable("Cinemas");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Nome)
            .IsRequired()
            .HasMaxLength(100);

        // Relacionamento com Endereco
        builder.HasOne(c => c.Endereco)
            .WithOne(e => e.Cinema)
            .HasForeignKey<Cinema>(c => c.EnderecoId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade); // Exemplo de como configurar a exclusão em cascata

        // Relacionamento com Filmes
        builder.HasMany(c => c.Sessoes)
            .WithOne(s => s.Cinema)
            .HasForeignKey(s => s.CinemaId);
    }
}
