using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;
public class NoteAppContext : DbContext
{
    public NoteAppContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Auditoria> Auditorias {get; set;}
    public DbSet<BlockChain> BlockChains {get; set;}
    public DbSet<EstadoNotificacion> EstadoNotificaciones { get; set; }
    public DbSet<Formato> Formatos { get; set; }
    public DbSet<HiloRespuestaNotificacion> HiloRespuestaNotificaciones { get; set; }
    public DbSet<ModuloNotificacion> ModuloNotificaciones { get; set; }
    public DbSet<Radicado> Radicados { get; set; }
    public DbSet<TipoNotificacion> TipoNotificaciones { get; set; }
    public DbSet<TipoRequerimiento> TipoRequerimientos { get; set; }
    public DbSet<Rol> Roles {get; set;}
    public DbSet<PermisoGenerico> PermisosGenericos { get; set; }
    public DbSet<ModuloMaestro> ModulosMaestros { get; set; }
    public DbSet<Submodulo> Submodulos { get; set; }
    public DbSet<MaestroVsSubmodulo> MaestrosVsSubmodulos { get; set; }
    public DbSet<RolVsMaestro> RolesVsMaestros { get; set; }
    public DbSet<GenericoVsSubmodulo> GenericosVsSubmodulos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
