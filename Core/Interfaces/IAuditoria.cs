using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IAuditoria : IGenericRepository<Auditoria>
    {
        
    }
}