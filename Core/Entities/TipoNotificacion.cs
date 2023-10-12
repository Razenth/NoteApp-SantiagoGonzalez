using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class TipoNotificacion : BaseEntity
    {
        public string NombreTipo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public ICollection<ModuloNotificacion> ModulosNotificaciones { get; set; }
        public ICollection<BlockChain> BlockChains { get; set; }
    }
}