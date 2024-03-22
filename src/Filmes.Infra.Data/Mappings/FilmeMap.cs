using Filmes.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Filmes.Infra.Data.Mappings;

public class FilmeMap : IEntityTypeConfiguration<Filme>
{
    public void Configure(EntityTypeBuilder<Filme> builder)
    {
        builder.ToTable("Filmes");

        builder.HasKey(f => f.Id);

        builder.Property(f => f.Titulo)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(f => f.Genero)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(f => f.Sinopse)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(f => f.Duracao)
            .IsRequired();

        builder.Property(f => f.ImagemCapa)
            .IsRequired()
            .HasMaxLength(500);
    }
}