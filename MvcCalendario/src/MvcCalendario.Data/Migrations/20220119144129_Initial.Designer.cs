// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MvcCalendario.Data.Context;

namespace MvcCalendario.Data.Migrations
{
    [DbContext(typeof(MvcContext))]
    [Migration("20220119144129_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MvcCalendario.Business.Models.Agenda", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Ativo")
                        .HasColumnType("int");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataAgenda")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Agenda");
                });

            modelBuilder.Entity("MvcCalendario.Business.Models.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CPF")
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<int>("Grupo")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("MvcCalendario.Business.Models.Contato", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Celular")
                        .HasColumnType("varchar(11)");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<bool>("EhWhatsApp")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("Principal")
                        .HasColumnType("bit");

                    b.Property<string>("Telefone")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Contato");
                });

            modelBuilder.Entity("MvcCalendario.Business.Models.Endereco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bairro")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("varchar(8)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Complemento")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Numero")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasColumnType("varchar(2)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("MvcCalendario.Business.Models.Agenda", b =>
                {
                    b.HasOne("MvcCalendario.Business.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("MvcCalendario.Business.Models.Contato", b =>
                {
                    b.HasOne("MvcCalendario.Business.Models.Cliente", null)
                        .WithMany("Contatos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MvcCalendario.Business.Models.Endereco", b =>
                {
                    b.HasOne("MvcCalendario.Business.Models.Cliente", null)
                        .WithMany("Enderecos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MvcCalendario.Business.Models.Cliente", b =>
                {
                    b.Navigation("Contatos");

                    b.Navigation("Enderecos");
                });
#pragma warning restore 612, 618
        }
    }
}
