using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaces
{
    public interface ISeccionAD
    {
        List<SP_recSecciones_Result> recSeccioneS();

        SP_recSeccionPorId_Result recSeccionesXId(int pId);

        List<SP_recSeccionesPorCiclo_Result> recSeccionesPorCiclo(int idCiclo);

        bool insSeccion(Seccione pobjSeccion);

        bool modSeccion(Seccione pobjSeccion);

        bool delSeccionn(Seccione pobjSeccion);
    }
}
