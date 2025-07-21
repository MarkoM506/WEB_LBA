using AccesoDatos;
using AccesoDatos.Implementacion;
using AccesoDatos.Interfaces;
using Entidades;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;

namespace LogicaNegocio.Implementacion
{
    public class AsistenciaLN : IAsistenciaLN
    {
        public static L_BAEntities _gobjContextoLBA = new L_BAEntities();
        private readonly IAsistenciaAD _objAsistenciaAD = new AsistenciaAD(_gobjContextoLBA);

        public List<SP_recAsistencias_Result> recAsistenciasln()
        {
            try
            {
                return _objAsistenciaAD.recAsistenciAs();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SP_recAsistenciaPorId_Result recAsistenciaXIdln(int pId)
        {
            try
            {
                return _objAsistenciaAD.recAsistenciaXId(pId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Asistencia> obtenerAsistenciasPorFiltroLN(int mes, int anio, int id_profesor, int id_materia, int id_seccion)
        {
            try
            {
                return _objAsistenciaAD.obtenerAsistenciasPorFiltro(mes, anio, id_profesor, id_materia, id_seccion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool eliminarAsistenciaPorFechaLN(int idEstudiante, int idProfesor, int idMateria, DateTime fecha)
        {
            try
            {
                return _objAsistenciaAD.eliminarAsistenciaPorFechaAD(idEstudiante, idProfesor, idMateria, fecha);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Asistencia buscarAsistenciaPorClaveln(int idEstudiante, DateTime fecha, int idProfesor, int idMateria)
        {
            try
            {
                return _objAsistenciaAD.buscarAsistenciaPorClave(idEstudiante, fecha, idProfesor, idMateria);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool insAsistencialn(Asistencia asistencia)
        {
            try
            {
                return _objAsistenciaAD.insAsistenciA(asistencia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool modAsistencialn(Asistencia asistencia)
        {
            try
            {
                return _objAsistenciaAD.modAsistenciA(asistencia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool delAsistencialn(Asistencia asistencia)
        {
            try
            {
                return _objAsistenciaAD.delAsistenciA(asistencia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Estados_Asistencia> obtenerEstadosDesdeTablAln()
        {
            try
            {
                return _objAsistenciaAD.obtenerEstadosDesdeTabla();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<AsistenciaPorSeccionDTO> reportePorSeccionln(int idSeccion)
        {
            try
            {
                return _objAsistenciaAD.reportePorSeccion(idSeccion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ReporteAsistenciaMensualDTO> reporteMensualln(int anio, int mes, int? idProfesor = null, int? idSeccion = null, int? idMateria = null)
        {
            try
            {
                if (!idProfesor.HasValue || !idSeccion.HasValue || !idMateria.HasValue)
                    throw new ArgumentException("Debe indicar profesor, sección y materia.");

                return _objAsistenciaAD.reporteMensual(anio, mes, idProfesor.Value, idSeccion.Value, idMateria.Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}