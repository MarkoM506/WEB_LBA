using AccesoDatos;
using AccesoDatos.Implementacion;
using AccesoDatos.Interfaces;
using Entidades;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Implementacion
{
    public class ProfesorLN : IProfesorLN
    {
        public static BD_LBAEntities _gobjContextoLBA = new BD_LBAEntities();
        private readonly ProfesorAD _objProfesorAD = new ProfesorAD(_gobjContextoLBA);

        public List<SP_recProfesores_Result> recProfesoresLN()
        {
            List<SP_recProfesores_Result> lobjRespuesta = new List<SP_recProfesores_Result>();

            try
            {
                lobjRespuesta = _objProfesorAD.recProfesoreS();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lobjRespuesta;
        }

        public SP_recProfesorPorId_Result recProfesorXIdLN(int pId)
        {
            SP_recProfesorPorId_Result objRespuesta = new SP_recProfesorPorId_Result();

            try
            {
                objRespuesta = _objProfesorAD.recProfesoresXId(pId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objRespuesta;
        }

        public bool insProfesorLN(Profesore pobjProfesor)
        {
            bool objRespuesta = new bool();

            try
            {
                objRespuesta = _objProfesorAD.insProfesores(pobjProfesor);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objRespuesta;
        }

        public bool modProfesorLN(Profesore pobjProfesor)
        {
            bool objRespuesta = new bool();

            try
            {
                objRespuesta = _objProfesorAD.modProfesores(pobjProfesor);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objRespuesta;
        }

        public bool delProfesorLN(Profesore pobjProfesor)
        {
            bool objRespuesta = new bool();

            try
            {
                objRespuesta = _objProfesorAD.delProfesores(pobjProfesor);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objRespuesta;
        }

        // ================================
        // NUEVOS MÉTODOS: Materias_Profesores
        // ================================

        public List<SP_recMateriasPorProfesor_Result> obtenerMateriasPorProfesorLN(int idProfesor)
        {
            List<SP_recMateriasPorProfesor_Result> lobjRespuesta = new List<SP_recMateriasPorProfesor_Result>();

            try
            {
                lobjRespuesta = _objProfesorAD.obtenerMateriasPorProfesor(idProfesor);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lobjRespuesta;
        }

        public List<SP_recProfesoresPorMateria_Result> obtenerProfesoresPorMateriaLN(int idMateria)
        {
            List<SP_recProfesoresPorMateria_Result> lobjRespuesta = new List<SP_recProfesoresPorMateria_Result>();

            try
            {
                lobjRespuesta = _objProfesorAD.obtenerProfesoresPorMateria(idMateria);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lobjRespuesta;
        }

        public List<SP_recProfesoresConMaterias_Result> listarProfesoresConMateriasLN()
        {
            List<SP_recProfesoresConMaterias_Result> lobjRespuesta = new List<SP_recProfesoresConMaterias_Result>();

            try
            {
                lobjRespuesta = _objProfesorAD.listarProfesoresConMaterias();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lobjRespuesta;
        }

        public bool vincularMateriaAProfesorLN(int idProfesor, int idMateria)
        {
            bool objRespuesta = new bool();

            try
            {
                objRespuesta = _objProfesorAD.vincularMateriaAProfesor(idProfesor, idMateria);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objRespuesta;
        }

        public bool removerMateriaDeProfesorLN(int idProfesor, int idMateria)
        {
            bool objRespuesta = new bool();

            try
            {
                objRespuesta = _objProfesorAD.removerMateriaDeProfesor(idProfesor, idMateria);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objRespuesta;
        }
    }
}
