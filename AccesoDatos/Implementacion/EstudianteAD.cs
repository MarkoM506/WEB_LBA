using AccesoDatos.Interfaces;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Implementacion
{
    public class EstudianteAD : IEstudianteAD
    {
        private L_BAEntities gobjContextoLBA;

        public EstudianteAD(L_BAEntities _gobjContexto)
        {
            this.gobjContextoLBA = _gobjContexto;
        }


        public List<SP_recEstudiantes_Result> recEstudiantee()
        {
            List<SP_recEstudiantes_Result> lobjRespuesta = new List<SP_recEstudiantes_Result>();

            try
            {
                lobjRespuesta = gobjContextoLBA.SP_recEstudiantes().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lobjRespuesta;
        }
        // Obtener los estudiantes de una seccion en específico
        public List<SP_recEstudiantesPorSeccion_Result> recEstudiantesXSeccion(int idSeccion)
        {
            List<SP_recEstudiantesPorSeccion_Result> lobjRespuesta = new List<SP_recEstudiantesPorSeccion_Result>();

            try
            {
                lobjRespuesta = gobjContextoLBA.SP_recEstudiantesPorSeccion(idSeccion).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lobjRespuesta;
        }
        // Metodo para buscar estudiante x cedula
        public SP_recEstudiantePorCedula_Result recEstudianteXCedula(string cedula)
        {
            SP_recEstudiantePorCedula_Result objRespuesta = null;

            try
            {
                objRespuesta = gobjContextoLBA.SP_recEstudiantePorCedula(cedula).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objRespuesta;
        }
        public List<SP_recPadresPorEstudiante_Result> obtenerPadresPorEstudiante(int idEstudiante)
        {
            try
            {
                return gobjContextoLBA.SP_recPadresPorEstudiante(idEstudiante).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // LLAMAR POR EL ID
        public SP_recEstudiantePorId_Result recEstudianteXId(int pId)
        {
            SP_recEstudiantePorId_Result objRespuesta = new SP_recEstudiantePorId_Result();

            try
            {
                objRespuesta = gobjContextoLBA.SP_recEstudiantePorId(pId).Single();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objRespuesta;
        }
        public bool insEstudiantee(Estudiante pobjEstudiante)
        {
            var proxyCreationEnable = gobjContextoLBA.Configuration.ProxyCreationEnabled;

            bool objRespuesta = new bool();

            try
            {
                objRespuesta = false;

                int intVal = 0;

                intVal = gobjContextoLBA.SP_insEstudiante(pobjEstudiante.cedula, pobjEstudiante.nombre, pobjEstudiante.direccion, pobjEstudiante.telefono, pobjEstudiante.id_seccion);

                if (intVal == 1)
                {
                    objRespuesta = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                gobjContextoLBA.Configuration.ProxyCreationEnabled = proxyCreationEnable;
            }
            return objRespuesta;
        }
        public bool modEstudiantee(Estudiante pobjEstudiante)
        {
            var proxyCreationEnable = gobjContextoLBA.Configuration.ProxyCreationEnabled;

            bool objRespuesta = new bool();

            try
            {
                objRespuesta = false;

                int intVal = 0;

                intVal = gobjContextoLBA.SP_modEstudiante(pobjEstudiante.id_estudiante, pobjEstudiante.cedula, pobjEstudiante.nombre, pobjEstudiante.direccion, pobjEstudiante.telefono, pobjEstudiante.id_seccion);

                if (intVal == 1)
                {
                    objRespuesta = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                gobjContextoLBA.Configuration.ProxyCreationEnabled = proxyCreationEnable;
            }
            return objRespuesta;
        }
        public bool delEstudiantee(Estudiante pobjEstudiante)
        {
            var proxyCreationEnable = gobjContextoLBA.Configuration.ProxyCreationEnabled;

            bool objRespuesta = new bool();

            try
            {
                objRespuesta = false;

                int intVal = 0;

                intVal = gobjContextoLBA.SP_delEstudiante(pobjEstudiante.id_estudiante);

                if (intVal == 1)
                {
                    objRespuesta = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                gobjContextoLBA.Configuration.ProxyCreationEnabled = proxyCreationEnable;
            }
            return objRespuesta;
        }
    }

}

