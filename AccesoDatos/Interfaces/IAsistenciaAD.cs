using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaces
{
    public interface IAsistenciaAD
    {
        List<SP_recAsistencias_Result> recAsistenciAs();
        SP_recAsistenciaPorId_Result recAsistenciaXId(int pId);
        bool insAsistenciA(Asistencia asistencia);
        bool modAsistenciA(Asistencia asistencia);
        bool delAsistenciA(Asistencia asistencia);

        bool eliminarAsistenciaPorFechaAD(int idEstudiante, int idProfesor, int idMateria, DateTime fecha);
        List<Estados_Asistencia> obtenerEstadosDesdeTabla();
        List<AsistenciaPorSeccionDTO> reportePorSeccion(int idSeccion);
        List<ReporteAsistenciaMensualDTO> reporteMensual(int anio, int mes, int? idProfesor, int? idSeccion, int? idMateria);
        List<Asistencia> obtenerAsistenciasPorFiltro(int mes, int anio, int id_profesor, int id_materia, int id_seccion);

        Asistencia buscarAsistenciaPorClave(int idEstudiante, DateTime fecha, int idProfesor, int idMateria);
    }
}
