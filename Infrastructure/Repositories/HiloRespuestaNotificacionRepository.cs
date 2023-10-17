using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class HiloRespuestaNotificacionRepository : GenericRepository<HiloRespuestaNotificacion>, IHiloRepuestaNotificacion
    {
        private readonly NoteAppContext _context;
        public HiloRespuestaNotificacionRepository(NoteAppContext context) : base(context)
        {
            _context = context;
        }
    }
}