using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MvcCalendario.Business.Models;

namespace MvcCalendario.Data.Mappings
{
    public class AgendaMapping : IEntityTypeConfiguration<Agenda>
    {

        public void Configure(EntityTypeBuilder<Agenda> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Titulo)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.ToTable("Agenda");
        }
    }
}
