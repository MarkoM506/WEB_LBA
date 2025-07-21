using Entidades;
using System.Collections.Generic;

namespace LogicaNegocio.Interfaces
{
    public interface IMateriaLN
    {
        List<SP_recMaterias_Result> recMateriasln();
        List<SP_recMateriasConProfesores_Result> recMateriasConProfesln();
        SP_recMateriaPorId_Result recMateriaXIdln(int idMateria);
        bool insMaterialn(Materia materia);
        bool modMaterialn(Materia materia);
        bool delMaterialn(Materia materia);
    }
}
