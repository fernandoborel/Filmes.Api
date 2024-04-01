using Filmes.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Filmes.Infra.Data.Mappings;

public class EnderecoMap : IEntityTypeConfiguration<Endereco>
{
    public void Configure(EntityTypeBuilder<Endereco> builder)
    {
        builder.ToTable("Enderecos");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Logradouro)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(e => e.Numero)
            .IsRequired()
            .HasMaxLength(10);

        // Relacionamento com Cinema
        builder.HasOne(e => e.Cinema)
            .WithOne(c => c.Endereco)
            .HasForeignKey<Cinema>(c => c.EnderecoId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}
