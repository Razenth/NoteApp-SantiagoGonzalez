using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class GenericoVsSubmoduloRepository : GenericRepository<GenericoVsSubmodulo>, IGenericoVsSubmodulo
    {
        private readonly NoteAppContext _context;
        public GenericoVsSubmoduloRepository(NoteAppContext context) : base(context)
        {
            _context = context;
        }
    }
}