﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Prototype.Infra.Data;

namespace Prototype.Infra.Data.Migrations
{
    [DbContext(typeof(PrototypeDataContext))]
    partial class PrototypeDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Prototype.Domain.Entities.BeneficioServidor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnName("CPF")
                        .HasColumnType("nvarchar(11)")
                        .HasMaxLength(11);

                    b.Property<string>("Matricula")
                        .IsRequired()
                        .HasColumnName("Matricula")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.Property<string>("Orgao")
                        .IsRequired()
                        .HasColumnName("Orgao")
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SetorDescricao")
                        .HasColumnName("SetorDescricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SetorTramitacao")
                        .HasColumnName("Setor_Atual")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Servidores");
                });

            modelBuilder.Entity("Prototype.Domain.Entities.Carrinho", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<Guid>("Id_Produto")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("Id_Produto")
                        .IsUnique();

                    b.ToTable("Carrinho");
                });

            modelBuilder.Entity("Prototype.Domain.Entities.Documento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<Guid?>("BeneficioServidorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Categoria")
                        .HasColumnName("Categoria")
                        .HasColumnType("int");

                    b.Property<string>("CategoriaDescicao")
                        .HasColumnName("CategoriaDescicao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileAsBase64")
                        .IsRequired()
                        .HasColumnName("Arquivo_Base64")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("FileAsByteArray")
                        .IsRequired()
                        .HasColumnName("Bytes")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnName("Nome_Arquivo")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("FileSize")
                        .IsRequired()
                        .HasColumnName("Tamanho_Arquivo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileType")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Tipo")
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("application/pdf");

                    b.Property<DateTime>("LastModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Ultima_Modificacao")
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2021, 4, 5, 23, 37, 41, 92, DateTimeKind.Local).AddTicks(6900));

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ServidorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BeneficioServidorId");

                    b.HasIndex("ServidorId");

                    b.ToTable("Documentos");
                });

            modelBuilder.Entity("Prototype.Domain.Entities.ProcessoTramitacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataTramitacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Data_Tramitacao")
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2021, 4, 5, 23, 37, 41, 99, DateTimeKind.Local).AddTicks(4125));

                    b.Property<Guid?>("DocumentoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ServidorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("SetorDestino")
                        .HasColumnName("Setor_Destino")
                        .HasColumnType("int");

                    b.Property<string>("SetorDestinoDescricao")
                        .HasColumnName("Setor_Destino_Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SetorOrigem")
                        .HasColumnName("Setor_Origem")
                        .HasColumnType("int");

                    b.Property<string>("SetorOrigemDescricao")
                        .HasColumnName("Setor_Origem_Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioMovimentacao")
                        .IsRequired()
                        .HasColumnName("Usuario")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("DocumentoId");

                    b.HasIndex("ServidorId");

                    b.ToTable("Tramitacao");
                });

            modelBuilder.Entity("Prototype.Domain.Entities.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<Guid?>("Id_Promocao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Tem_Promocao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("Id_Promocao")
                        .IsUnique()
                        .HasFilter("[Id_Promocao] IS NOT NULL");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("Prototype.Domain.Entities.Promocao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<int>("Leve")
                        .HasColumnType("int");

                    b.Property<int>("Pague")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Valor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18,2)")
                        .HasDefaultValue(0m);

                    b.HasKey("Id");

                    b.ToTable("Promocoes");
                });

            modelBuilder.Entity("Prototype.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Email")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100)
                        .HasDefaultValue("admin@prototype.com");

                    b.Property<string>("Login")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Login")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50)
                        .HasDefaultValue("Admin");

                    b.Property<string>("Password")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Password")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15)
                        .HasDefaultValue("123456");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Prototype.Domain.Entities.Carrinho", b =>
                {
                    b.HasOne("Prototype.Domain.Entities.Produto", "Produto")
                        .WithOne()
                        .HasForeignKey("Prototype.Domain.Entities.Carrinho", "Id_Produto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Prototype.Domain.Entities.Documento", b =>
                {
                    b.HasOne("Prototype.Domain.Entities.BeneficioServidor", null)
                        .WithMany("Documentos")
                        .HasForeignKey("BeneficioServidorId");

                    b.HasOne("Prototype.Domain.Entities.BeneficioServidor", "Servidor")
                        .WithMany()
                        .HasForeignKey("ServidorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Prototype.Domain.Entities.ProcessoTramitacao", b =>
                {
                    b.HasOne("Prototype.Domain.Entities.BeneficioServidor", "Documento")
                        .WithMany()
                        .HasForeignKey("DocumentoId");

                    b.HasOne("Prototype.Domain.Entities.BeneficioServidor", null)
                        .WithMany("Tramitacoes")
                        .HasForeignKey("ServidorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Prototype.Domain.Entities.Produto", b =>
                {
                    b.HasOne("Prototype.Domain.Entities.Promocao", "Promocao")
                        .WithOne()
                        .HasForeignKey("Prototype.Domain.Entities.Produto", "Id_Promocao");
                });
#pragma warning restore 612, 618
        }
    }
}
