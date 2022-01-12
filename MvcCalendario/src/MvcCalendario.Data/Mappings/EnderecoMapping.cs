using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MvcCalendario.Business.Models;

namespace MvcCalendario.Data.Mappings
{
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Logradouro)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Cep)
                .IsRequired()
                .HasColumnType("varchar(8)");

            builder.Property(p => p.Cidade)
                .IsRequired()
                .HasColumnType("varchar(500)");


            builder.Property(p => p.UF)
                .IsRequired()
                .HasColumnType("varchar(2)");

            builder.ToTable("Endereco");
        }
    }
}
