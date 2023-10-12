using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class BlockChainConfiguration : IEntityTypeConfiguration<BlockChain>
    {
        public void Configure(EntityTypeBuilder<BlockChain> builder)
        {
            builder.ToTable("BlockChain");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id);

            builder.HasOne(p => p.TiposNotificaciones)
            .WithMany(p => p.BlockChains)
            .HasForeignKey( p => p.IdNotificacion);

            builder.HasOne(p => p.HiloRespuestaNotificaciones)
            .WithMany(p => p.BlockChains)
            .HasForeignKey( p => p.IdHiloRespuesta);

            builder.HasOne(p => p.Auditorias)
            .WithMany(p => p.BlockChains)
            .HasForeignKey( p => p.IdAuditoria);

            builder.Property(p => p.HashGenerado)
            .IsRequired()
            .HasMaxLength(100);

            builder.Property(p => p.FechaCreacion)
            .HasColumnType("date");

            builder.Property(p => p.FechaModificacion)
            .HasColumnType("date");
        }
    }
}