using AccesoDatos.Implementacion;
using AccesoDatos.Interfaces;
using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.Interfaces;

namespace LogicaNegocio.Implementacion
{
    public class EstudianteLN : IEstudianteLN
    {
        public static BD_LBAEntities _gobjContextoLBA = new BD_LBAEntities();

        private readonly IEstudianteAD _objEstudianteAD = new EstudianteAD(_gobjContextoLBA);


        public List<SP_recEstudiantes_Result> recEstudianteln()
        {
            List<SP_recEstudiantes_Result> lobjRespuesta = new List<SP_recEstudiantes_Result>();

            try
            {
                lobjRespuesta = _objEstudianteAD.recEstudiantee();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lobjRespuesta;
        }
        public List<SP_recEstudiantesPorSeccion_Result> recEstudiantesPorSeccionln(int idSeccion)
        {
            List<SP_recEstudiantesPorSeccion_Result> lobjRespuesta = new List<SP_recEstudiantesPorSeccion_Result>();

            try
            {
                lobjRespuesta = _objEstudianteAD.recEstudiantesXSeccion(idSeccion);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lobjRespuesta;
        }

        public SP_recEstudiantePorCedula_Result recEstudiantePorCedulaln(string cedula)
        {
            SP_recEstudiantePorCedula_Result objRespuesta = null;

            try
            {
                objRespuesta = _objEstudianteAD.recEstudianteXCedula(cedula);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objRespuesta;
        }
        public List<SP_recPadresPorEstudiante_Result> obtenerPadresPorEstudianteLN(int idEstudiante)
        {
            try
            {
                return _objEstudianteAD.obtenerPadresPorEstudiante(idEstudiante);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public SP_recEstudiantePorId_Result recEstudianteXIdln(int pId)
        {
            SP_recEstudiantePorId_Result objRespuesta = new SP_recEstudiantePorId_Result();

            try
            {
                objRespuesta = _objEstudianteAD.recEstudianteXId(pId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objRespuesta;
        }
        public bool insEstudianteln(Estudiante pobjEstudiante)
        {
            bool objRespuesta = new bool();

            try
            {
                objRespuesta = _objEstudianteAD.insEstudiantee(pobjEstudiante);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objRespuesta;
        }
        public bool modEstudianteln(Estudiante pobjEstudiante)
        {
            bool objRespuesta = new bool();

            try
            {
                objRespuesta = _objEstudianteAD.modEstudiantee(pobjEstudiante);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objRespuesta;
        }
        public bool delEstudianteln(Estudiante pobjEstudiante)
        {
            bool objRespuesta = new bool();

            try
            {
                objRespuesta = _objEstudianteAD.delEstudiantee(pobjEstudiante);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objRespuesta;
        }
    }
}
