using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MvcCalendario.Business.Models;

namespace MvcCalendario.Data.Mappings
{
    public class ContatoMapping : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Celular)
               
               .HasColumnType("varchar(11)");

            builder.ToTable("Contato");
        }
    }
}
