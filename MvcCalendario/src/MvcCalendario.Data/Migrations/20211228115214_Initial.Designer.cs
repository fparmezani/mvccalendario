﻿// <auto-generated />
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
    [Migration("20211228115214_Initial")]
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
                        .HasColumnType("varchar(100)");

                    b.Property<Guid>("ContatoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(100)");

                    b.Property<Guid>("EnderecoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Grupo")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("ContatoId");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("MvcCalendario.Business.Models.Contato", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CelularId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<bool>("EhWhatsApp")
                        .HasColumnType("bit");

                    b.Property<bool>("Principal")
                        .HasColumnType("bit");

                    b.Property<Guid?>("TelefoneId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CelularId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("TelefoneId");

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
                        .HasColumnType("varchar(7)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

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

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("MvcCalendario.Business.Models.Telefone", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DDD")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Numero")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Telefone");
                });

            modelBuilder.Entity("MvcCalendario.Business.Models.Agenda", b =>
                {
                    b.HasOne("MvcCalendario.Business.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("MvcCalendario.Business.Models.Cliente", b =>
                {
                    b.HasOne("MvcCalendario.Business.Models.Contato", "Contato")
                        .WithMany()
                        .HasForeignKey("ContatoId")
                        .IsRequired();

                    b.HasOne("MvcCalendario.Business.Models.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .IsRequired();

                    b.Navigation("Contato");

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("MvcCalendario.Business.Models.Contato", b =>
                {
                    b.HasOne("MvcCalendario.Business.Models.Telefone", "Celular")
                        .WithMany()
                        .HasForeignKey("CelularId");

                    b.HasOne("MvcCalendario.Business.Models.Cliente", null)
                        .WithMany("Contatos")
                        .HasForeignKey("ClienteId");

                    b.HasOne("MvcCalendario.Business.Models.Telefone", "Telefone")
                        .WithMany()
                        .HasForeignKey("TelefoneId");

                    b.Navigation("Celular");

                    b.Navigation("Telefone");
                });

            modelBuilder.Entity("MvcCalendario.Business.Models.Cliente", b =>
                {
                    b.Navigation("Contatos");
                });
#pragma warning restore 612, 618
        }
    }
}