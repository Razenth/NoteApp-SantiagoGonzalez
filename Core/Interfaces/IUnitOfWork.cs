using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUnitOfWork
    {
        IAuditoria Auditorias { get; }
        IBlockChain BlockChains {get;}
        IEstadoNotificacion EstadoNotificaciones {get;}
        IFormato Formatos {get;}
        IGenericoVsSubmodulo GenericosVsSubmodulos {get;}
        IHiloRepuestaNotificacion HiloRepuestaNotificaciones {get;}
        IMaestroVsSubmodulo MaestrosVsSubmodulos {get;}
        IModuloMaestro ModulosMaestros {get;}
        IModuloNotificacion ModulosNotificaciones {get;}
        IPermisoGenerico PermisosGenericos {get;}
        IRadicado Radicados {get;}
        IRol Roles {get;}
        IRolVsMaestro RolesVsMaestro {get;}
        ISubmodulo Submodulos {get;}
        ITipoNotificacion TipoNotificaciones {get;}
        ITipoRequerimiento TipoRequerimientos {get;}
        Task<int> SaveAsync();
    }
}