using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB_LBA.Models
{
    public class M_AsistenciaConsulta
    {
        public int id_asistencia { get; set; }

        public string estudiante { get; set; }
        public string materia { get; set; }
        public string profesor { get; set; }
        public string estado { get; set; }

        public DateTime fecha { get; set; }
        public string observaciones { get; set; }
    }
}