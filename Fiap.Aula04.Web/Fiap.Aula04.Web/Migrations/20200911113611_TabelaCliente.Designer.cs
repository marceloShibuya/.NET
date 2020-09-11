﻿// <auto-generated />
using System;
using Fiap.Aula04.Web.Persistencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Fiap.Aula04.Web.Migrations
{
    [DbContext(typeof(ConcessionariaContext))]
    [Migration("20200911113611_TabelaCliente")]
    partial class TabelaCliente
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Fiap.Aula04.Web.Models.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.Property<bool>("Pcd")
                        .HasColumnType("bit");

                    b.HasKey("ClienteId");

                    b.ToTable("Tbl_Cliente");
                });

            modelBuilder.Entity("Fiap.Aula04.Web.Models.Veiculo", b =>
                {
                    b.Property<int>("VeiculoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Ano")
                        .HasColumnType("int");

                    b.Property<int>("Combustivel")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataFabricacao")
                        .HasColumnName("Dt_Fabricacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("Novo")
                        .HasColumnType("bit");

                    b.HasKey("VeiculoId");

                    b.ToTable("Tbl_Veiculo");
                });
#pragma warning restore 612, 618
        }
    }
}
