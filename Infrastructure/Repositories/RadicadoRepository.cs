using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class RadicadoRepository : GenericRepository<Radicado> , IRadicado
    {
        private readonly NoteAppContext _context;
        public RadicadoRepository(NoteAppContext context) : base(context)
        {
            _context = context;
        }
    }
}