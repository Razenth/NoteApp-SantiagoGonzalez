﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(NoteAppContext))]
    partial class NoteAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Core.Entities.Auditoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DescAccion")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("date");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("date");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Auditoria", (string)null);
                });

            modelBuilder.Entity("Core.Entities.BlockChain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("date");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("date");

                    b.Property<string>("HashGenerado")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("IdAuditoria")
                        .HasColumnType("int");

                    b.Property<int>("IdHiloRespuesta")
                        .HasColumnType("int");

                    b.Property<int>("IdNotificacion")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdAuditoria");

                    b.HasIndex("IdHiloRespuesta");

                    b.HasIndex("IdNotificacion");

                    b.ToTable("BlockChain", (string)null);
                });

            modelBuilder.Entity("Core.Entities.EstadoNotificacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("date");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("date");

                    b.Property<string>("NombreEstado")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("EstadoNotificacion", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Formato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("date");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("date");

                    b.Property<string>("NombreFormato")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Formato", (string)null);
                });

            modelBuilder.Entity("Core.Entities.HiloRespuestaNotificacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("date");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("date");

                    b.Property<string>("NombreTipo")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.HasKey("Id");

                    b.ToTable("HiloRespuestaNotificacion", (string)null);
                });

            modelBuilder.Entity("Core.Entities.ModuloNotificacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AsuntoNotificacion")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("date");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("date");

                    b.Property<int>("IdEstadoNotificacion")
                        .HasColumnType("int");

                    b.Property<int>("IdFormato")
                        .HasColumnType("int");

                    b.Property<int>("IdHiloRespuesta")
                        .HasColumnType("int");

                    b.Property<int>("IdRadicado")
                        .HasColumnType("int");

                    b.Property<int>("IdRequerimiento")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoNotificacion")
                        .HasColumnType("int");

                    b.Property<string>("TextoNotificacion")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("varchar(2000)");

                    b.HasKey("Id");

                    b.HasIndex("IdEstadoNotificacion");

                    b.HasIndex("IdFormato");

                    b.HasIndex("IdHiloRespuesta");

                    b.HasIndex("IdRadicado");

                    b.HasIndex("IdRequerimiento");

                    b.HasIndex("IdTipoNotificacion");

                    b.ToTable("ModuloNotificaciones");
                });

            modelBuilder.Entity("Core.Entities.Radicado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("date");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.ToTable("Radicado", (string)null);
                });

            modelBuilder.Entity("Core.Entities.TipoNotificacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("date");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("date");

                    b.Property<string>("NombreTipo")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.HasKey("Id");

                    b.ToTable("TipoNotificacion", (string)null);
                });

            modelBuilder.Entity("Core.Entities.TipoRequerimiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("date");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("date");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.HasKey("Id");

                    b.ToTable("TipoRequerimiento", (string)null);
                });

            modelBuilder.Entity("Core.Entities.BlockChain", b =>
                {
                    b.HasOne("Core.Entities.Auditoria", "Auditorias")
                        .WithMany("BlockChains")
                        .HasForeignKey("IdAuditoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.HiloRespuestaNotificacion", "HiloRespuestaNotificaciones")
                        .WithMany("BlockChains")
                        .HasForeignKey("IdHiloRespuesta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.TipoNotificacion", "TiposNotificaciones")
                        .WithMany("BlockChains")
                        .HasForeignKey("IdNotificacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Auditorias");

                    b.Navigation("HiloRespuestaNotificaciones");

                    b.Navigation("TiposNotificaciones");
                });

            modelBuilder.Entity("Core.Entities.ModuloNotificacion", b =>
                {
                    b.HasOne("Core.Entities.EstadoNotificacion", "EstadoNotificaciones")
                        .WithMany("ModulosNotificaciones")
                        .HasForeignKey("IdEstadoNotificacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Formato", "Formatos")
                        .WithMany("ModulosNotificaciones")
                        .HasForeignKey("IdFormato")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.HiloRespuestaNotificacion", "HiloRespuestaNotificaciones")
                        .WithMany("ModulosNotificaciones")
                        .HasForeignKey("IdHiloRespuesta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Radicado", "Radicados")
                        .WithMany("ModulosNotificaciones")
                        .HasForeignKey("IdRadicado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.TipoRequerimiento", "TipoRequerimientos")
                        .WithMany("ModulosNotificaciones")
                        .HasForeignKey("IdRequerimiento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.TipoNotificacion", "TiposNotificaciones")
                        .WithMany("ModulosNotificaciones")
                        .HasForeignKey("IdTipoNotificacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EstadoNotificaciones");

                    b.Navigation("Formatos");

                    b.Navigation("HiloRespuestaNotificaciones");

                    b.Navigation("Radicados");

                    b.Navigation("TipoRequerimientos");

                    b.Navigation("TiposNotificaciones");
                });

            modelBuilder.Entity("Core.Entities.Auditoria", b =>
                {
                    b.Navigation("BlockChains");
                });

            modelBuilder.Entity("Core.Entities.EstadoNotificacion", b =>
                {
                    b.Navigation("ModulosNotificaciones");
                });

            modelBuilder.Entity("Core.Entities.Formato", b =>
                {
                    b.Navigation("ModulosNotificaciones");
                });

            modelBuilder.Entity("Core.Entities.HiloRespuestaNotificacion", b =>
                {
                    b.Navigation("BlockChains");

                    b.Navigation("ModulosNotificaciones");
                });

            modelBuilder.Entity("Core.Entities.Radicado", b =>
                {
                    b.Navigation("ModulosNotificaciones");
                });

            modelBuilder.Entity("Core.Entities.TipoNotificacion", b =>
                {
                    b.Navigation("BlockChains");

                    b.Navigation("ModulosNotificaciones");
                });

            modelBuilder.Entity("Core.Entities.TipoRequerimiento", b =>
                {
                    b.Navigation("ModulosNotificaciones");
                });
#pragma warning restore 612, 618
        }
    }
}