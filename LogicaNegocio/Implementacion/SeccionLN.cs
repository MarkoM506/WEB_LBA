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
    public class SeccionLN : ISeccionLN
    {

        public static L_BAEntities _gobjContextoLBA = new   L_BAEntities();

        private readonly ISeccionAD _objSeccionAD = new SeccionAD(_gobjContextoLBA);


        public List<SP_recSecciones_Result> recSeccionln()
        {
            List<SP_recSecciones_Result> lobjRespuesta = new List<SP_recSecciones_Result>();

            try
            {
                lobjRespuesta = _objSeccionAD.recSeccioneS();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lobjRespuesta;
        }
        public List<SP_recSeccionesPorCiclo_Result> recSeccionesPorCicloLN(int idCiclo)
        {
            List<SP_recSeccionesPorCiclo_Result> lobjRespuesta = new List<SP_recSeccionesPorCiclo_Result>();

            try
            {
                lobjRespuesta = _objSeccionAD.recSeccionesPorCiclo(idCiclo);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lobjRespuesta;
        }
        public SP_recSeccionPorId_Result recSeccionXIdln(int pId)
        {
            SP_recSeccionPorId_Result objRespuesta = new SP_recSeccionPorId_Result();

            try
            {
                objRespuesta = _objSeccionAD.recSeccionesXId(pId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objRespuesta;
        }
        public bool insSeccionln(Seccione pobjSeccion)
        {
            bool objRespuesta = new bool();

            try
            {
                objRespuesta = _objSeccionAD.insSeccion(pobjSeccion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objRespuesta;
        }
        public bool modSeccionln(Seccione pobjSeccion)
        {
            bool objRespuesta = new bool();

            try
            {
                objRespuesta = _objSeccionAD.modSeccion(pobjSeccion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objRespuesta;
        }
        public bool delSeccionln(Seccione pobjSeccion)
        {
            bool objRespuesta = new bool();

            try
            {
                objRespuesta = _objSeccionAD.delSeccionn(pobjSeccion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objRespuesta;
        }
    }
}
