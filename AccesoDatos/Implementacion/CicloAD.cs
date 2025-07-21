using AccesoDatos.Interfaces;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Implementacion
{
    public class CicloAD : ICiclosAD
    {

        private L_BAEntities gobjContextoLBA;

        public CicloAD(L_BAEntities _gobjContexto)
        {
            this.gobjContextoLBA = _gobjContexto;
        }


        public List<SP_recCiclos_Result> recCicloS()
        {
            List<SP_recCiclos_Result> lobjRespuesta = new List<SP_recCiclos_Result>();

            try
            {
                lobjRespuesta = gobjContextoLBA.SP_recCiclos().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lobjRespuesta;
        }

        // LLAMAR POR EL ID
        public SP_recCicloPorId_Result recCiclosXId(int pId)
        {
            SP_recCicloPorId_Result objRespuesta = new SP_recCicloPorId_Result();

            try
            {
                objRespuesta = gobjContextoLBA.SP_recCicloPorId(pId).Single();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objRespuesta;
        }
        public bool insCiclos(Ciclo pobjCiclo)
        {
            var proxyCreationEnable = gobjContextoLBA.Configuration.ProxyCreationEnabled;

            bool objRespuesta = new bool();

            try
            {
                objRespuesta = false;

                int intVal = 0;

                intVal = gobjContextoLBA.SP_insCiclo(pobjCiclo.nombre_ciclo, pobjCiclo.descripcion);

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
        public bool modCiclos(Ciclo pobjCiclo)
        {
            var proxyCreationEnable = gobjContextoLBA.Configuration.ProxyCreationEnabled;

            bool objRespuesta = new bool();

            try
            {
                objRespuesta = false;

                int intVal = 0;

                intVal = gobjContextoLBA.SP_modCiclo(pobjCiclo.id_ciclo, pobjCiclo.nombre_ciclo, pobjCiclo.descripcion);

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
        public bool delCiclos(Ciclo pobjCiclo)
        {
            var proxyCreationEnable = gobjContextoLBA.Configuration.ProxyCreationEnabled;

            bool objRespuesta = new bool();

            try
            {
                objRespuesta = false;

                int intVal = 0;

                intVal = gobjContextoLBA.SP_delCiclo(pobjCiclo.id_ciclo);

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
