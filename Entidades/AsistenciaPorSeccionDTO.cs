using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class AsistenciaPorSeccionDTO
    {
        public int id_estudiante { get; set; }
        public string nombre_estudiante { get; set; }
        public DateTime fecha { get; set; }
        public string nombre_estado { get; set; }
    }
}
