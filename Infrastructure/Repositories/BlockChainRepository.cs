using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class BlockChainRepository : GenericRepository<BlockChain>, IBlockChain
    {
        private readonly NoteAppContext _context;
        public BlockChainRepository(NoteAppContext context) : base(context)
        {
            _context = context;
        }
    }
}