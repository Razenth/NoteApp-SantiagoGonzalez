using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNoteApp.Dtos
{
    public class GenericoVsSubmoduloDto
    {
        public int Id { get; set; }
        public int IdGenericos { get; set; }
        public int IdSubmodulos { get; set; }
        public int IdRol { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}