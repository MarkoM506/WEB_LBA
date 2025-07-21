using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Interfaces
{
    public interface IAsistenciaLN
    {
        List<SP_recAsistencias_Result> recAsistenciasln();
        SP_recAsistenciaPorId_Result recAsistenciaXIdln(int pId);
        bool insAsistencialn(Asistencia asistencia);
        bool modAsistencialn(Asistencia asistencia);
        bool delAsistencialn(Asistencia asistencia);
        bool eliminarAsistenciaPorFechaLN(int idEstudiante, int idProfesor, int idMateria, DateTime fecha);

        List<Estados_Asistencia> obtenerEstadosDesdeTablAln();
        List<AsistenciaPorSeccionDTO> reportePorSeccionln(int idSeccion);
        List<ReporteAsistenciaMensualDTO> reporteMensualln(int anio, int mes, int? idProfesor = null, int? idSeccion = null, int? idMateria = null);
        List<Asistencia> obtenerAsistenciasPorFiltroLN(int mes, int anio, int id_profesor, int id_materia, int id_seccion);
        Asistencia buscarAsistenciaPorClaveln(int idEstudiante, DateTime fecha, int idProfesor, int idMateria);
    }
}
