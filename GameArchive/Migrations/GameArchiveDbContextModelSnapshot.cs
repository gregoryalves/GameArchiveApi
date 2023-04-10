﻿// <auto-generated />
using System;
using GameArchive.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GameArchive.Migrations
{
    [DbContext(typeof(GameArchiveDbContext))]
    partial class GameArchiveDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GameArchive.Models.DesenvolvedoraModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Desenvolvedoras");
                });

            modelBuilder.Entity("GameArchive.Models.GeneroModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Generos");
                });

            modelBuilder.Entity("GameArchive.Models.JogoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DesenvolvedoraId")
                        .HasColumnType("int");

                    b.Property<int>("FaixaEtaria")
                        .HasColumnType("int");

                    b.Property<int>("GeneroId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("PlataformaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DesenvolvedoraId");

                    b.HasIndex("GeneroId");

                    b.HasIndex("PlataformaId");

                    b.ToTable("Jogos");
                });

            modelBuilder.Entity("GameArchive.Models.PlataformaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Plataformas");
                });

            modelBuilder.Entity("GameArchive.Models.PlataformaUsuarioModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Controles")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("PlataformaId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlataformaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("PlataformasUsuarios");
                });

            modelBuilder.Entity("GameArchive.Models.UsuarioJogoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataAquisicao")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<bool>("EhMidiaFisica")
                        .HasColumnType("bit");

                    b.Property<bool>("JaZerado")
                        .HasColumnType("bit");

                    b.Property<int>("JogoId")
                        .HasColumnType("int");

                    b.Property<int>("Nota")
                        .HasColumnType("int");

                    b.Property<decimal>("PrecoPago")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("JogoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("UsuariosJogos");
                });

            modelBuilder.Entity("GameArchive.Models.UsuarioModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("GameArchive.Models.JogoModel", b =>
                {
                    b.HasOne("GameArchive.Models.DesenvolvedoraModel", "Desenvolvedora")
                        .WithMany()
                        .HasForeignKey("DesenvolvedoraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameArchive.Models.GeneroModel", "Genero")
                        .WithMany()
                        .HasForeignKey("GeneroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameArchive.Models.PlataformaModel", "Plataforma")
                        .WithMany()
                        .HasForeignKey("PlataformaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Desenvolvedora");

                    b.Navigation("Genero");

                    b.Navigation("Plataforma");
                });

            modelBuilder.Entity("GameArchive.Models.PlataformaUsuarioModel", b =>
                {
                    b.HasOne("GameArchive.Models.PlataformaModel", "Plataforma")
                        .WithMany()
                        .HasForeignKey("PlataformaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameArchive.Models.UsuarioModel", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plataforma");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("GameArchive.Models.UsuarioJogoModel", b =>
                {
                    b.HasOne("GameArchive.Models.JogoModel", "Jogo")
                        .WithMany()
                        .HasForeignKey("JogoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameArchive.Models.UsuarioModel", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Jogo");

                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
