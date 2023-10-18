﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(NoteAppContext))]
    [Migration("20231018152607_ActualizacionMigrations")]
    partial class ActualizacionMigrations
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("Core.Entities.GenericoVsSubmodulo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("date");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("date");

                    b.Property<int>("IdGenericos")
                        .HasColumnType("int");

                    b.Property<int>("IdRol")
                        .HasColumnType("int");

                    b.Property<int>("IdSubmodulos")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdGenericos");

                    b.HasIndex("IdRol");

                    b.HasIndex("IdSubmodulos");

                    b.ToTable("GenericoVsSubmodulo", (string)null);
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

            modelBuilder.Entity("Core.Entities.MaestroVsSubmodulo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("date");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("date");

                    b.Property<int>("IdMaestro")
                        .HasColumnType("int");

                    b.Property<int>("IdSubmodulo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdMaestro");

                    b.HasIndex("IdSubmodulo");

                    b.ToTable("MaestroVsSubmodulo", (string)null);
                });

            modelBuilder.Entity("Core.Entities.ModuloMaestro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NombreModulo")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("ModulosMaestros");
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

                    b.ToTable("ModuloNotificaciones", (string)null);
                });

            modelBuilder.Entity("Core.Entities.PermisoGenerico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("date");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("date");

                    b.Property<string>("NombrePermiso")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("PermisoGenerico", (string)null);
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

            modelBuilder.Entity("Core.Entities.Rol", b =>
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
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Rol", (string)null);
                });

            modelBuilder.Entity("Core.Entities.RolVsMaestro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("date");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("date");

                    b.Property<int>("IdMaestro")
                        .HasColumnType("int");

                    b.Property<int>("IdRol")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdMaestro");

                    b.HasIndex("IdRol");

                    b.ToTable("RolVsMaestro", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Submodulo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("date");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("date");

                    b.Property<string>("NombreSubmodulo")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.HasKey("Id");

                    b.ToTable("Submodulo", (string)null);
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

            modelBuilder.Entity("Core.Entities.GenericoVsSubmodulo", b =>
                {
                    b.HasOne("Core.Entities.PermisoGenerico", "PermisosGenericos")
                        .WithMany("GenericosVsSubmodulos")
                        .HasForeignKey("IdGenericos")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Rol", "Roles")
                        .WithMany("GenericosVsSubmodulos")
                        .HasForeignKey("IdRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.MaestroVsSubmodulo", "MaestrosVsSubmodulos")
                        .WithMany("GenericosVsSubmodulos")
                        .HasForeignKey("IdSubmodulos")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MaestrosVsSubmodulos");

                    b.Navigation("PermisosGenericos");

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("Core.Entities.MaestroVsSubmodulo", b =>
                {
                    b.HasOne("Core.Entities.ModuloMaestro", "ModulosMaestros")
                        .WithMany("MaestrosVsSubmodulos")
                        .HasForeignKey("IdMaestro")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Submodulo", "Submodulos")
                        .WithMany("MaestrosVsSubmodulos")
                        .HasForeignKey("IdSubmodulo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ModulosMaestros");

                    b.Navigation("Submodulos");
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

            modelBuilder.Entity("Core.Entities.RolVsMaestro", b =>
                {
                    b.HasOne("Core.Entities.ModuloMaestro", "ModulosMaestros")
                        .WithMany("RolesVsMaestros")
                        .HasForeignKey("IdMaestro")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Rol", "Roles")
                        .WithMany("RolesVsMaestros")
                        .HasForeignKey("IdRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ModulosMaestros");

                    b.Navigation("Roles");
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

            modelBuilder.Entity("Core.Entities.MaestroVsSubmodulo", b =>
                {
                    b.Navigation("GenericosVsSubmodulos");
                });

            modelBuilder.Entity("Core.Entities.ModuloMaestro", b =>
                {
                    b.Navigation("MaestrosVsSubmodulos");

                    b.Navigation("RolesVsMaestros");
                });

            modelBuilder.Entity("Core.Entities.PermisoGenerico", b =>
                {
                    b.Navigation("GenericosVsSubmodulos");
                });

            modelBuilder.Entity("Core.Entities.Radicado", b =>
                {
                    b.Navigation("ModulosNotificaciones");
                });

            modelBuilder.Entity("Core.Entities.Rol", b =>
                {
                    b.Navigation("GenericosVsSubmodulos");

                    b.Navigation("RolesVsMaestros");
                });

            modelBuilder.Entity("Core.Entities.Submodulo", b =>
                {
                    b.Navigation("MaestrosVsSubmodulos");
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
