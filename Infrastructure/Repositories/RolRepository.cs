using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class RolRepository : GenericRepository<Rol> , IRol
    {
        private readonly NoteAppContext _context;
        public RolRepository(NoteAppContext context) : base(context)
        {
            _context = context;
        }
    }
}