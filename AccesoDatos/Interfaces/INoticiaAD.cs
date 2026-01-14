using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaces
{
    public interface INoticiaAD
    {

        List<SP_recNoticias_Result> recNoticias();

        SP_recNoticiaPorId_Result recNoticiaPorId(int id);


        bool insNoticia(Noticia noticia);
        bool modNoticia(Noticia noticia);
        bool delNoticia(Noticia noticia);
    }
}
