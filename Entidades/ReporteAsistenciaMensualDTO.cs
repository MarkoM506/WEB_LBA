using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ReporteAsistenciaMensualDTO
    {
        public string estudiante { get; set; }
        public string seccion { get; set; }
        public string materia { get; set; }
        public string profesor { get; set; }

        // Alias para vista (opcional)
        public string nombre_estudiante => estudiante;

        // Mapa Día → Símbolo ('✔', '❌', 'J', 'T', etc.)
        public Dictionary<string, string> simbolos { get; set; } = new Dictionary<string, string>();

        // Totales por tipo de asistencia
        public int total_presente { get; set; }
        public int total_faltas { get; set; }
        public int total_justificada { get; set; }
        public int total_tardanza { get; set; }

        // Porcentaje general
        public decimal porcentaje_asistencia { get; set; }
    }
}
