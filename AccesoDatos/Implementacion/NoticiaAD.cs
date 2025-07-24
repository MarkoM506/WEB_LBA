using AccesoDatos.Interfaces;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccesoDatos.Implementacion
{
    public class NoticiaAD : INoticiaAD
    {
        private BD_LBAEntities gobjContextoLBA;

        public NoticiaAD(BD_LBAEntities _gobjContexto)
        {
            this.gobjContextoLBA = _gobjContexto;
        }

        public List<SP_recNoticias_Result> recNoticias()
        {
            List<SP_recNoticias_Result> lobjRespuesta = new List<SP_recNoticias_Result>();

            try
            {
                lobjRespuesta = gobjContextoLBA.SP_recNoticias().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lobjRespuesta;
        }

        public SP_recNoticiaPorId_Result recNoticiaPorId(int id)
        {
            SP_recNoticiaPorId_Result objRespuesta = new SP_recNoticiaPorId_Result();

            try
            {
                objRespuesta = gobjContextoLBA.SP_recNoticiaPorId(id).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objRespuesta;
        }

        public bool insNoticia(Noticia noticia)
        {
            var proxyEnabled = gobjContextoLBA.Configuration.ProxyCreationEnabled;

            bool objRespuesta = false;

            try
            {
                gobjContextoLBA.Configuration.ProxyCreationEnabled = false;

                int intVal = gobjContextoLBA.SP_insNoticia(noticia.titulo, noticia.contenido, noticia.fecha_publicacion, noticia.imagen_url);

                objRespuesta = (intVal == 1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                gobjContextoLBA.Configuration.ProxyCreationEnabled = proxyEnabled;
            }

            return objRespuesta;
        }

        public bool modNoticia(Noticia noticia)
        {
            var proxyEnabled = gobjContextoLBA.Configuration.ProxyCreationEnabled;

            bool objRespuesta = false;

            try
            {
                gobjContextoLBA.Configuration.ProxyCreationEnabled = false;

                int intVal = gobjContextoLBA.SP_modNoticia(noticia.id_noticia, noticia.titulo, noticia.contenido, noticia.fecha_publicacion, noticia.imagen_url);

                objRespuesta = (intVal == 1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                gobjContextoLBA.Configuration.ProxyCreationEnabled = proxyEnabled;
            }

            return objRespuesta;
        }

        public bool delNoticia(Noticia noticia)
        {
            var proxyEnabled = gobjContextoLBA.Configuration.ProxyCreationEnabled;

            bool objRespuesta = false;

            try
            {
                gobjContextoLBA.Configuration.ProxyCreationEnabled = false;

                int intVal = gobjContextoLBA.SP_delNoticia(noticia.id_noticia);

                objRespuesta = (intVal == 1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                gobjContextoLBA.Configuration.ProxyCreationEnabled = proxyEnabled;
            }

            return objRespuesta;
        }
    }
}