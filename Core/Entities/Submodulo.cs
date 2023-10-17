using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Submodulo : BaseEntity
    {
        public string NombreSubmodulo { get; set; }
        public ICollection<MaestroVsSubmodulo> MaestrosVsSubmodulos { get; set; }
    }
}