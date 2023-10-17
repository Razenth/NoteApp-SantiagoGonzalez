using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class RolVsMaestro : BaseEntity
    {
        public int IdMaestro { get; set; }
        public ModuloMaestro ModulosMaestros { get; set; }
        public int IdRol { get; set; }
        public Rol Roles { get; set; }
    }
}