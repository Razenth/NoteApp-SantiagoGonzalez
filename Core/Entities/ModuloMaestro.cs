using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class ModuloMaestro : BaseEntity
    {
        public string NombreModulo { get; set; }
        public ICollection<MaestroVsSubmodulo> MaestrosVsSubmodulos { get; set; }
        public ICollection<RolVsMaestro> RolesVsMaestros { get; set; }    
    }
}