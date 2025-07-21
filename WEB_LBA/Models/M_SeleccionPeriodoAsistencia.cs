using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB_LBA.Models
{
    public class M_SeleccionPeriodoAsistencia
    {
        public int IdSeccion { get; set; }
        public int IdProfesor { get; set; }
        public int IdMateria { get; set; }

        public int Anio { get; set; }
        public int Mes { get; set; }

        public List<Entidades.Estudiante> Estudiantes { get; set; }
    }
}