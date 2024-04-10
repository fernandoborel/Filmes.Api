using Filmes.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Filmes.Infra.Data.Mappings;

public class UsuarioMap : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("Usuario");

        builder.HasKey(p => p.IdUsuario);

        builder.Property(p => p.IdUsuario)
            .HasColumnName("IdUsuario");

        builder.Property(p => p.Nome)
            .HasColumnName("Nome")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.Email)
            .HasColumnType("VARCHAR(100)")
            .IsRequired();

        builder.HasIndex(p => p.Email)
            .IsUnique();

        builder.Property(p => p.Senha)
            .HasColumnType("VARCHAR(100)")
            .IsRequired();
    }
}