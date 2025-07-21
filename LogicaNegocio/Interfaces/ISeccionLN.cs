using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Interfaces
{
    public interface ISeccionLN
    {

        List<SP_recSecciones_Result> recSeccionln();

        List<SP_recSeccionesPorCiclo_Result> recSeccionesPorCicloLN(int idCiclo);

        SP_recSeccionPorId_Result recSeccionXIdln(int pId);

        bool insSeccionln(Seccione pobjSeccion);

        bool modSeccionln(Seccione pobjSeccion);

        bool delSeccionln(Seccione pobjSeccion);
    }
}
