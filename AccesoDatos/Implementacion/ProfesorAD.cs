using AccesoDatos.Interfaces;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Implementacion
{
    public class ProfesorAD : IProfesorAD
    {
        private L_BAEntities gobjContextoLBA;

        public ProfesorAD(L_BAEntities _gobjContexto)
        {
            this.gobjContextoLBA = _gobjContexto;
        }

        public List<SP_recProfesores_Result> recProfesoreS()
        {
            List<SP_recProfesores_Result> lobjRespuesta = new List<SP_recProfesores_Result>();

            try
            {
                lobjRespuesta = gobjContextoLBA.SP_recProfesores().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lobjRespuesta;
        }

        public SP_recProfesorPorId_Result recProfesoresXId(int pId)
        {
            SP_recProfesorPorId_Result objRespuesta = new SP_recProfesorPorId_Result();

            try
            {
                objRespuesta = gobjContextoLBA.SP_recProfesorPorId(pId).Single();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objRespuesta;
        }

        public bool insProfesores(Profesore pobjProfe)
        {
            var proxyCreationEnable = gobjContextoLBA.Configuration.ProxyCreationEnabled;
            bool objRespuesta = new bool();

            try
            {
                objRespuesta = false;
                int intVal = 0;

                intVal = gobjContextoLBA.SP_insProfesor(pobjProfe.cedula, pobjProfe.nombre);

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

        public bool modProfesores(Profesore pobjProfe)
        {
            var proxyCreationEnable = gobjContextoLBA.Configuration.ProxyCreationEnabled;
            bool objRespuesta = new bool();

            try
            {
                objRespuesta = false;
                int intVal = 0;

                intVal = gobjContextoLBA.SP_modProfesor(pobjProfe.id_profesor, pobjProfe.cedula, pobjProfe.nombre);

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

        public bool delProfesores(Profesore pobjProfe)
        {
            var proxyCreationEnable = gobjContextoLBA.Configuration.ProxyCreationEnabled;
            bool objRespuesta = new bool();

            try
            {
                objRespuesta = false;
                int intVal = 0;

                intVal = gobjContextoLBA.SP_delProfesor(pobjProfe.id_profesor);

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

        // ================================
        // NUEVOS MÉTODOS: Materias_Profesores
        // ================================

        public List<SP_recMateriasPorProfesor_Result> obtenerMateriasPorProfesor(int idProfesor)
        {
            List<SP_recMateriasPorProfesor_Result> lobjRespuesta = new List<SP_recMateriasPorProfesor_Result>();

            try
            {
                lobjRespuesta = gobjContextoLBA.SP_recMateriasPorProfesor(idProfesor).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lobjRespuesta;
        }

        public List<SP_recProfesoresPorMateria_Result> obtenerProfesoresPorMateria(int idMateria)
        {
            List<SP_recProfesoresPorMateria_Result> lobjRespuesta = new List<SP_recProfesoresPorMateria_Result>();

            try
            {
                lobjRespuesta = gobjContextoLBA.SP_recProfesoresPorMateria(idMateria).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lobjRespuesta;
        }

        public List<SP_recProfesoresConMaterias_Result> listarProfesoresConMaterias()
        {
            List<SP_recProfesoresConMaterias_Result> lobjRespuesta = new List<SP_recProfesoresConMaterias_Result>();

            try
            {
                lobjRespuesta = gobjContextoLBA.SP_recProfesoresConMaterias().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lobjRespuesta;
        }

        public bool vincularMateriaAProfesor(int idProfesor, int idMateria)
        {
            bool objRespuesta = new bool();

            try
            {
                gobjContextoLBA.SP_asignarMateriaAProfesor(idProfesor, idMateria);
                objRespuesta = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objRespuesta;
        }

        public bool removerMateriaDeProfesor(int idProfesor, int idMateria)
        {
            bool objRespuesta = new bool();

            try
            {
                gobjContextoLBA.SP_quitarMateriaDeProfesor(idProfesor, idMateria);
                objRespuesta = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objRespuesta;
        }
    }
}
