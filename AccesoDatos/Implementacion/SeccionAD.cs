using AccesoDatos.Interfaces;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Implementacion
{
    public class SeccionAD : ISeccionAD
    {

        private L_BAEntities gobjContextoLBA;

        public SeccionAD(L_BAEntities _gobjContexto)
        {
            this.gobjContextoLBA = _gobjContexto;
        }


        public List<SP_recSecciones_Result> recSeccioneS()
        {
            List<SP_recSecciones_Result> lobjRespuesta = new List<SP_recSecciones_Result>();

            try
            {
                lobjRespuesta = gobjContextoLBA.SP_recSecciones().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lobjRespuesta;
        }
        // Obtener las secciones de un ciclo específico
        public List<SP_recSeccionesPorCiclo_Result> recSeccionesPorCiclo(int idCiclo)
        {
            List<SP_recSeccionesPorCiclo_Result> lobjRespuesta = new List<SP_recSeccionesPorCiclo_Result>();

            try
            {
                lobjRespuesta = gobjContextoLBA.SP_recSeccionesPorCiclo(idCiclo).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lobjRespuesta;
        }

        // LLAMAR POR EL ID
        public SP_recSeccionPorId_Result recSeccionesXId(int pId)
        {
            SP_recSeccionPorId_Result objRespuesta = new SP_recSeccionPorId_Result();

            try
            {
                objRespuesta = gobjContextoLBA.SP_recSeccionPorId(pId).Single();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objRespuesta;
        }
        public bool insSeccion(Seccione pobjSeccion)
        {
            var proxyCreationEnable = gobjContextoLBA.Configuration.ProxyCreationEnabled;

            bool objRespuesta = new bool();

            try
            {
                objRespuesta = false;

                int intVal = 0;

                intVal = gobjContextoLBA.SP_insSeccion(pobjSeccion.nombre_seccion, pobjSeccion.id_ciclo);

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
        public bool modSeccion(Seccione pobjSeccion)
        {
            var proxyCreationEnable = gobjContextoLBA.Configuration.ProxyCreationEnabled;

            bool objRespuesta = new bool();

            try
            {
                objRespuesta = false;

                int intVal = 0;

                intVal = gobjContextoLBA.SP_modSeccion(pobjSeccion.id_seccion, pobjSeccion.nombre_seccion, pobjSeccion.id_ciclo);

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
        public bool delSeccionn(Seccione pobjSeccion)
        {
            var proxyCreationEnable = gobjContextoLBA.Configuration.ProxyCreationEnabled;

            bool objRespuesta = new bool();

            try
            {
                objRespuesta = false;

                int intVal = 0;

                intVal = gobjContextoLBA.SP_delSeccion(pobjSeccion.id_seccion);

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