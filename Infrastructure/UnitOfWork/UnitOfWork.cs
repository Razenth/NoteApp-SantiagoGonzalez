using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;

namespace Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly NoteAppContext _context;
    public UnitOfWork(NoteAppContext context)
    {
        _context = context;
    }
    private AuditoriaRepository _auditoria;
    public IAuditoria Auditorias 
    {
        get
        {
            if(_auditoria == null)
            {
                _auditoria = new AuditoriaRepository(_context);
            }
            return _auditoria;
        }
    }
    private BlockChainRepository _blockChain;
    public IBlockChain BlockChains
    {
        get
        {
            if(_blockChain == null)
            {
                _blockChain = new BlockChainRepository(_context);
            }
            return _blockChain;
        }
    }
    private EstadoNotificacionRepository _estadoNotifi;
    public IEstadoNotificacion EstadoNotificaciones
    {
        get
        {
            if(_estadoNotifi == null)
            {
                _estadoNotifi = new EstadoNotificacionRepository(_context);
            }
            return _estadoNotifi;
        }
    }
    private FormatoRepository _formato;
    public IFormato Formatos 
    {
        get
        {
            if(_formato == null)
            {
                _formato = new FormatoRepository(_context);
            }
            return _formato;
        }
    }
    private GenericoVsSubmoduloRepository _genericoVsModulo;
    public IGenericoVsSubmodulo GenericosVsSubmodulos 
    {
        get
        {
            if(_genericoVsModulo == null)
            {
                _genericoVsModulo = new GenericoVsSubmoduloRepository(_context);
            }
            return _genericoVsModulo;
        }
    }
    private HiloRespuestaNotificacionRepository _hiloNotificacion;
    public IHiloRepuestaNotificacion HiloRepuestaNotificaciones 
    {
        get
        {
            if(_hiloNotificacion == null)
            {
                _hiloNotificacion = new HiloRespuestaNotificacionRepository(_context);
            }
            return _hiloNotificacion;
        }
    }
    private MaestroVsSubmoduloRepository _maestroVsSubmodulo;
    public IMaestroVsSubmodulo MaestrosVsSubmodulos
    {
        get
        {
            if(_maestroVsSubmodulo == null)
            {
                _maestroVsSubmodulo = new MaestroVsSubmoduloRepository(_context);
            }
            return _maestroVsSubmodulo;
        }
    }
    private ModuloMaestroRepository _moduloMaestro;
    public IModuloMaestro ModulosMaestros
    {
        get
        {
            if(_moduloMaestro == null)
            {
                _moduloMaestro = new ModuloMaestroRepository(_context);
            }
            return _moduloMaestro;
        }
    }
    private ModuloNotificacionRepository _moduloNotificacion;
    public IModuloNotificacion ModulosNotificaciones
    {
        get
        {
            if(_moduloNotificacion == null)
            {
                _moduloNotificacion = new ModuloNotificacionRepository(_context);
            }
            return _moduloNotificacion;
        }
    }
    private PermisoGenericoRepository _permisoGenerico;
    public IPermisoGenerico PermisosGenericos
    {
        get
        {
            if(_permisoGenerico == null)
            {
                _permisoGenerico = new PermisoGenericoRepository(_context);
            }
            return _permisoGenerico;
        }
    }
    private RadicadoRepository _radicado;
    public IRadicado Radicados
    {
        get
        {
            if (_radicado == null)
            {
                _radicado = new RadicadoRepository(_context);
            } 
            return _radicado;
        }
    }
    private RolRepository _rol;
    public IRol Roles{
        get
        {
            if(_rol == null)
            {
                _rol = new RolRepository(_context);
            }
            return _rol;
        }
    }
    private RolVsMaestroRepository _rolVsMaestro;
    public IRolVsMaestro RolesVsMaestro{
        get
        {
            if(_rolVsMaestro == null)
            {
                _rolVsMaestro = new RolVsMaestroRepository(_context);
            }
            return _rolVsMaestro;
        }
    }
    private SubmoduloRepository _submodulo;
    public ISubmodulo Submodulos
    {
        get
        {
            if(_submodulo == null)
            {
                _submodulo = new SubmoduloRepository(_context);
            }
            return _submodulo;
        }
    }
    private TipoNotificacionRepository _tipoNotificacion;
    public ITipoNotificacion TipoNotificaciones
    {
        get
        {
            if(_tipoNotificacion == null)
            {
                _tipoNotificacion = new TipoNotificacionRepository(_context);
            }
            return _tipoNotificacion;
        }
    }
    private TipoRequerimientoRepository _tipoRequerimiento;
    public ITipoRequerimiento TipoRequerimientos
    {
        get
        {
            if(_tipoRequerimiento == null)
            {
                _tipoRequerimiento = new TipoRequerimientoRepository(_context); 
            }
            return _tipoRequerimiento;
        }
    }
    public void Dispose()
    {
        throw new NotImplementedException();
    }
    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
