using AccesoDatos;
using AccesoDatos.Implementacion;
using AccesoDatos.Interfaces;
using Entidades;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;

namespace LogicaNegocio.Implementacion
{
    public class NoticiaLN : INoticiaLN
    {
        // Instancia estática del contexto para mantener consistencia
        public static L_BAEntities _gobjContextoLBA = new L_BAEntities();

        // Acceso a Datos (como en CicloLN)
        private readonly INoticiaAD _objNoticiaAD = new NoticiaAD(_gobjContextoLBA);

        public List<SP_recNoticias_Result> recNoticiasLN()
        {
            List<SP_recNoticias_Result> lobjRespuesta = new List<SP_recNoticias_Result>();

            try
            {
                lobjRespuesta = _objNoticiaAD.recNoticias();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lobjRespuesta;
        }

        public SP_recNoticiaPorId_Result recNoticiaPorIdLN(int id)
        {
            SP_recNoticiaPorId_Result objRespuesta = new SP_recNoticiaPorId_Result();

            try
            {
                objRespuesta = _objNoticiaAD.recNoticiaPorId(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objRespuesta;
        }

        public bool insNoticiaLN(Noticia noticia)
        {
            bool objRespuesta = false;

            try
            {
                objRespuesta = _objNoticiaAD.insNoticia(noticia);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objRespuesta;
        }

        public bool modNoticiaLN(Noticia noticia)
        {
            bool objRespuesta = false;

            try
            {
                objRespuesta = _objNoticiaAD.modNoticia(noticia);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objRespuesta;
        }

        public bool delNoticiaLN(Noticia noticia)
        {
            bool objRespuesta = false;

            try
            {
                objRespuesta = _objNoticiaAD.delNoticia(noticia);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objRespuesta;
        }
    }
}