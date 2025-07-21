using AccesoDatos.Interfaces;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace AccesoDatos.Implementacion
{
    public class AsistenciaAD : IAsistenciaAD
    {
        private L_BAEntities gobjContextoLBA;

        public AsistenciaAD(L_BAEntities _gobjContexto)
        {
            this.gobjContextoLBA = _gobjContexto;
        }

        public List<SP_recAsistencias_Result> recAsistenciAs()
        {
            return gobjContextoLBA.SP_recAsistencias().ToList();
        }
        public bool eliminarAsistenciaPorFechaAD(int idEstudiante, int idProfesor, int idMateria, DateTime fecha)
        {
            try
            {
                using (var contexto = new L_BAEntities())
                {
                    contexto.Configuration.ProxyCreationEnabled = false;

                    // Buscar el registro existente
                    var registro = contexto.Asistencias.FirstOrDefault(a =>
                        a.id_estudiante == idEstudiante &&
                        a.id_profesor == idProfesor &&
                        a.id_materia == idMateria &&
                        DbFunctions.TruncateTime(a.fecha) == fecha.Date);

                    if (registro != null)
                    {
                        contexto.Asistencias.Remove(registro);
                        contexto.SaveChanges();
                        return true;
                    }

                    return false; // no había nada que eliminar
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public SP_recAsistenciaPorId_Result recAsistenciaXId(int pId)
        {
            return gobjContextoLBA.SP_recAsistenciaPorId(pId).Single();
        }
        public List<Asistencia> obtenerAsistenciasPorFiltro(int mes, int anio, int id_profesor, int id_materia, int id_seccion)
        {
            var inicio = new DateTime(anio, mes, 1);
            var fin = inicio.AddMonths(1).AddDays(-1);

            return (from a in gobjContextoLBA.Asistencias
                    join est in gobjContextoLBA.Estudiantes on a.id_estudiante equals est.id_estudiante
                    where a.fecha >= inicio && a.fecha <= fin
                       && a.id_profesor == id_profesor
                       && a.id_materia == id_materia
                       && est.id_seccion == id_seccion
                    select a).ToList();
        }
        public Asistencia buscarAsistenciaPorClave(int idEstudiante, DateTime fecha, int idProfesor, int idMateria)
        {
            return gobjContextoLBA.Asistencias
                .FirstOrDefault(a =>
                    a.id_estudiante == idEstudiante &&
                    a.fecha == fecha &&
                    a.id_profesor == idProfesor &&
                    a.id_materia == idMateria);
        }

        public bool insAsistenciA(Asistencia asistencia)
        {
            var proxy = gobjContextoLBA.Configuration.ProxyCreationEnabled;
            gobjContextoLBA.Configuration.ProxyCreationEnabled = false;
            bool respuesta = false;

            try
            {
                gobjContextoLBA.SP_insAsistencia(
                    asistencia.id_estudiante,
                    asistencia.id_materia,
                    asistencia.id_profesor,
                    asistencia.fecha,
                    asistencia.id_estado,
                    asistencia.observaciones
                );
                respuesta = true;
            }
            finally
            {
                gobjContextoLBA.Configuration.ProxyCreationEnabled = proxy;
            }

            return respuesta;
        }

        public bool modAsistenciA(Asistencia asistencia)
        {
            var proxy = gobjContextoLBA.Configuration.ProxyCreationEnabled;
            gobjContextoLBA.Configuration.ProxyCreationEnabled = false;
            bool respuesta = false;

            try
            {
                gobjContextoLBA.SP_modAsistencia(
                    asistencia.id_asistencia,
                    asistencia.id_estado,
                    asistencia.observaciones
                );
                respuesta = true;
            }
            finally
            {
                gobjContextoLBA.Configuration.ProxyCreationEnabled = proxy;
            }

            return respuesta;
        }

        public bool delAsistenciA(Asistencia asistencia)
        {
            var proxy = gobjContextoLBA.Configuration.ProxyCreationEnabled;
            gobjContextoLBA.Configuration.ProxyCreationEnabled = false;
            bool respuesta = false;

            try
            {
                gobjContextoLBA.SP_delAsistencia(asistencia.id_asistencia);
                respuesta = true;
            }
            finally
            {
                gobjContextoLBA.Configuration.ProxyCreationEnabled = proxy;
            }

            return respuesta;
        }

        public List<Estados_Asistencia> obtenerEstadosDesdeTabla()
        {
            return gobjContextoLBA.Estados_Asistencia.ToList();
        }

        public List<AsistenciaPorSeccionDTO> reportePorSeccion(int idSeccion)
        {
            var resultado = gobjContextoLBA.Database.SqlQuery<AsistenciaPorSeccionDTO>(
                "EXEC SP_reporteAsistenciaPorSeccion @id_seccion",
                new SqlParameter("@id_seccion", idSeccion)
            ).ToList();

            return resultado;
        }

        public List<ReporteAsistenciaMensualDTO> reporteMensual(int anio, int mes, int? idProfesor, int? idSeccion, int? idMateria)
        {
            using (var db = new L_BAEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;

                var resultado = db.Database.SqlQuery<TempReporteMensual>(
                    "EXEC SP_reporteMensualAsistencia @anio, @mes, @idProfesor, @idSeccion, @idMateria",
                    new SqlParameter("@anio", anio),
                    new SqlParameter("@mes", mes),
                    new SqlParameter("@idProfesor", (object)idProfesor ?? DBNull.Value),
                    new SqlParameter("@idSeccion", (object)idSeccion ?? DBNull.Value),
                    new SqlParameter("@idMateria", (object)idMateria ?? DBNull.Value)
                ).ToList();

                var lista = resultado.Select(x => new ReporteAsistenciaMensualDTO
                {
                    estudiante = x.estudiante,
                    seccion = x.seccion,
                    materia = x.materia,
                    profesor = x.profesor,
                    simbolos = new Dictionary<string, string>
                    {
                        ["01"] = x.D1,
                        ["02"] = x.D2,
                        ["03"] = x.D3,
                        ["04"] = x.D4,
                        ["05"] = x.D5,
                        ["06"] = x.D6,
                        ["07"] = x.D7,
                        ["08"] = x.D8,
                        ["09"] = x.D9,
                        ["10"] = x.D10,
                        ["11"] = x.D11,
                        ["12"] = x.D12,
                        ["13"] = x.D13,
                        ["14"] = x.D14,
                        ["15"] = x.D15,
                        ["16"] = x.D16,
                        ["17"] = x.D17,
                        ["18"] = x.D18,
                        ["19"] = x.D19,
                        ["20"] = x.D20,
                        ["21"] = x.D21,
                        ["22"] = x.D22,
                        ["23"] = x.D23,
                        ["24"] = x.D24,
                        ["25"] = x.D25,
                        ["26"] = x.D26,
                        ["27"] = x.D27,
                        ["28"] = x.D28,
                        ["29"] = x.D29,
                        ["30"] = x.D30,
                        ["31"] = x.D31
                    },
                    total_presente = x.total_presente ?? 0,
                    total_faltas = x.total_faltas ?? 0,
                    total_justificada = x.total_justificada ?? 0,
                    total_tardanza = x.total_tardanza ?? 0,
                    porcentaje_asistencia = x.porcentaje_asistencia ?? 0
                }).ToList();

                return lista;
            }
        }
    }
}