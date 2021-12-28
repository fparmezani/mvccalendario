using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MvcCalendario.Business.Models;

namespace MvcCalendario.Data.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {

        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.ToTable("Cliente");
        }

    }
}
