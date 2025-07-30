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
    public class CicloLN : ICicloLN
    {

        //VER A DETALLE ESTOS PRIVS
        public static L_BAEntities _gobjContextoLBA = new L_BAEntities();

        private readonly ICiclosAD _objCicloAD = new CicloAD(_gobjContextoLBA);


        public List<SP_recCiclos_Result> recCiclosln()
        {
            List<SP_recCiclos_Result> lobjRespuesta = new List<SP_recCiclos_Result>();

            try
            {
                lobjRespuesta = _objCicloAD.recCicloS();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lobjRespuesta;
        }
        public SP_recCicloPorId_Result recCiclosXIdln(int pId)
        {
            SP_recCicloPorId_Result objRespuesta = new SP_recCicloPorId_Result();

            try
            {
                objRespuesta = _objCicloAD.recCiclosXId(pId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objRespuesta;
        }
        public bool insCiclosln(Ciclo pobjCiclo)
        {
            bool objRespuesta = new bool();

            try
            {
                objRespuesta = _objCicloAD.insCiclos(pobjCiclo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objRespuesta;
        }
        public bool modCiclosln(Ciclo pobjCiclo)
        {
            bool objRespuesta = new bool();

            try
            {
                objRespuesta = _objCicloAD.modCiclos(pobjCiclo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objRespuesta;
        }
        public bool delCiclosln(Ciclo pobjCiclo)
        {
            bool objRespuesta = new bool();

            try
            {
                objRespuesta = _objCicloAD.delCiclos(pobjCiclo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objRespuesta;
        }
    }

}
