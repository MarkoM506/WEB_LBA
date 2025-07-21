using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaces
{
    public interface IMateriaAD
    {
        List<SP_recMateriasConProfesores_Result> recMateriasConProfes();

        List<SP_recMaterias_Result> recMateriaS();

        SP_recMateriaPorId_Result recMateriaXId(int pId);

        bool insMateriA(Materia pobjMateria);

        bool modMateriA(Materia pobjMateria);

        bool delMateriA(Materia pobjMateria);


    }
}
