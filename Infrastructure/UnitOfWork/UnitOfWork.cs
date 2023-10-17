using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly NoteAppContext _context;
    public UnitOfWork(NoteAppContext context)
    {
        _context = context;
    }
    public IAuditoria Auditorias => throw new NotImplementedException();

    public IBlockChain BlockChains => throw new NotImplementedException();

    public IEstadoNotificacion EstadoNotificaciones => throw new NotImplementedException();

    public IFormato Formatos => throw new NotImplementedException();

    public IGenericoVsSubmodulo GenericosVsSubmodulos => throw new NotImplementedException();

    public IHiloRepuestaNotificacion HiloRepuestaNotificaciones => throw new NotImplementedException();

    public IMaestroVsSubmodulo MaestrosVsSubmodulos => throw new NotImplementedException();

    public IModuloMaestro ModulosMaestros => throw new NotImplementedException();

    public IModuloNotificacion ModulosNotificaciones => throw new NotImplementedException();

    public IPermisoGenerico PermisosGenericos => throw new NotImplementedException();

    public IRadicado Radicados => throw new NotImplementedException();

    public IRol Roles => throw new NotImplementedException();

    public IRolVsMaestro RolesVsMaestro => throw new NotImplementedException();

    public ISubmodulo Submodulos => throw new NotImplementedException();

    public ITipoNotificacion TipoNotificaciones => throw new NotImplementedException();

    public ITipoRequerimiento TipoRequerimientos => throw new NotImplementedException();

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}
