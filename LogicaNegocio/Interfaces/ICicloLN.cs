using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Interfaces
{
    public interface ICicloLN
    {
        List<SP_recCiclos_Result> recCiclosln();

        SP_recCicloPorId_Result recCiclosXIdln(int pId);

        bool insCiclosln(Ciclo pobjCiclo);

        bool modCiclosln(Ciclo pobjCiclo);

        bool delCiclosln(Ciclo pobjCiclo);

    }
}
