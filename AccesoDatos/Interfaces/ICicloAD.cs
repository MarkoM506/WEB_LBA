using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaces
{
    public interface ICiclosAD
    {
        List<SP_recCiclos_Result> recCicloS();

        SP_recCicloPorId_Result recCiclosXId(int pId);

        bool insCiclos(Ciclo pobjCiclo);

        bool modCiclos(Ciclo pobjCiclo);

        bool delCiclos(Ciclo pobjCiclo);


    }
}
