using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class RolVsMaestroRepository : GenericRepository<RolVsMaestro> , IRolVsMaestro
    {
        private readonly NoteAppContext _context;
        public RolVsMaestroRepository(NoteAppContext context) : base(context)
        {
            _context = context;
        }
    }
}