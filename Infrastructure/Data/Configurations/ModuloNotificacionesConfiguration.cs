using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class ModuloNotificacionesConfiguration : IEntityTypeConfiguration<ModuloNotificacion>
    {
        public void Configure(EntityTypeBuilder<ModuloNotificacion> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id);

            builder.Property(p => p.AsuntoNotificacion)
            .IsRequired()
            .HasMaxLength(80);

            builder.HasOne(p => p.TiposNotificaciones)
            .WithMany(p => p.ModulosNotificaciones)
            .HasForeignKey(p => p.IdTipoNotificacion);

            builder.HasOne(p => p.Radicados)
            .WithMany(p => p.ModulosNotificaciones)
            .HasForeignKey(p => p.IdRadicado);

            builder.HasOne(p => p.EstadoNotificaciones)
            .WithMany(p => p.ModulosNotificaciones)
            .HasForeignKey(p => p.IdEstadoNotificacion);

            builder.HasOne(p => p.HiloRespuestaNotificaciones)
            .WithMany(p => p.ModulosNotificaciones)
            .HasForeignKey(p => p.IdHiloRespuesta);

            builder.HasOne(p => p.Formatos)
            .WithMany(p => p.ModulosNotificaciones)
            .HasForeignKey(p => p.IdFormato);

            builder.HasOne(p => p.TipoRequerimientos)
            .WithMany(p => p.ModulosNotificaciones)
            .HasForeignKey(p => p.IdRequerimiento);

            builder.Property(p => p.TextoNotificacion)
            .IsRequired()
            .HasMaxLength(2000);

            builder.Property(p => p.FechaCreacion)
            .HasColumnType("date");

            builder.Property(p => p.FechaModificacion)
            .HasColumnType("date");
        }
    }
}