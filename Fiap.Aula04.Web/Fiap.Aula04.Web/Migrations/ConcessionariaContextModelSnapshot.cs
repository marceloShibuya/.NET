﻿// <auto-generated />
using System;
using Fiap.Aula04.Web.Persistencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Fiap.Aula04.Web.Migrations
{
    [DbContext(typeof(ConcessionariaContext))]
    partial class ConcessionariaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("Fiap.Aula04.Web.Models.Endereco", b =>
                {
                    b.Property<int>("EnderecoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.HasKey("EnderecoId");

                    b.ToTable("Tbl_Endereco");
                });

            modelBuilder.Entity("Fiap.Aula04.Web.Models.EnderecoCliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<int>("EnderecoId1")
                        .HasColumnType("int");

                    b.HasKey("ClienteId", "EnderecoId");

                    b.HasIndex("EnderecoId");

                    b.HasIndex("EnderecoId1");

                    b.ToTable("EnderecoCliente");
                });

            modelBuilder.Entity("Fiap.Aula04.Web.Models.Placa", b =>
                {
                    b.Property<int>("PlacaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(2)")
                        .HasMaxLength(2);

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("nvarchar(8)")
                        .HasMaxLength(8);

                    b.HasKey("PlacaId");

                    b.ToTable("Tbl_Placa");
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

                    b.Property<int?>("ClienteId")
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

                    b.Property<int>("PlacaId")
                        .HasColumnType("int");

                    b.HasKey("VeiculoId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("PlacaId");

                    b.ToTable("Tbl_Veiculo");
                });

            modelBuilder.Entity("Fiap.Aula04.Web.Models.EnderecoCliente", b =>
                {
                    b.HasOne("Fiap.Aula04.Web.Models.Cliente", "Cliente")
                        .WithMany("EnderecoClientes")
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fiap.Aula04.Web.Models.Endereco", "Endereco")
                        .WithMany("EnderecoClientes")
                        .HasForeignKey("EnderecoId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Fiap.Aula04.Web.Models.Veiculo", b =>
                {
                    b.HasOne("Fiap.Aula04.Web.Models.Cliente", "Cliente")
                        .WithMany("Veiculos")
                        .HasForeignKey("ClienteId");

                    b.HasOne("Fiap.Aula04.Web.Models.Placa", "Placa")
                        .WithMany()
                        .HasForeignKey("PlacaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
