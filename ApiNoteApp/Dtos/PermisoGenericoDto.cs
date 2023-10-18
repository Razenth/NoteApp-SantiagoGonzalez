using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNoteApp.Dtos
{
    public class PermisoGenericoDto
    {
        public int Id { get; set; }
        public string NombrePermiso { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}