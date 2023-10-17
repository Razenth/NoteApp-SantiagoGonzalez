using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Infrastructure.Data.Configurations
{
    public class MaestroVsSubmoduloConfiguration : IEntityTypeConfiguration<MaestroVsSubmodulo>
    {
        public void Configure(EntityTypeBuilder<MaestroVsSubmodulo> builder)
        {
            builder.ToTable("MaestroVsSubmodulo");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.HasOne(p => p.ModulosMaestros)
            .WithMany(p => p.MaestrosVsSubmodulos)
            .HasForeignKey(p => p.IdMaestro);

            builder.HasOne(p => p.Submodulos)
            .WithMany(p => p.MaestrosVsSubmodulos)
            .HasForeignKey(p => p.IdSubmodulo);

            builder.Property(p => p.FechaCreacion)
            .HasColumnType("date");

            builder.Property(p => p.FechaModificacion)
            .HasColumnType("date");

        }
    }
}