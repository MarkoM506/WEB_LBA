using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Interfaces
{
    public interface INoticiaLN
    {
        List<SP_recNoticias_Result> recNoticiasLN();
        SP_recNoticiaPorId_Result recNoticiaPorIdLN(int id);
        bool insNoticiaLN(Noticia noticia);
        bool modNoticiaLN(Noticia noticia);
        bool delNoticiaLN(Noticia noticia);
    }
}
