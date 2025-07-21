using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Interfaces
{
    public interface IPadreLN
    {
        List<SP_recPadres_Result> recPadresLN();
        SP_recPadrePorId_Result recPadrePorIdLN(int id);
        SP_recPadrePorCedula_Result recPadrePorCedulaLN(string cedula);
        bool insPadreLN(Padre padre);
        bool modPadreLN(Padre padre);
        bool delPadreLN(Padre padre);

        // Relación Padre - Estudiantes
        bool asignarEstudianteALN(int idPadre, int idEstudiante);
        bool quitarEstudianteDeLN(int idPadre, int idEstudiante);
        List<SP_recEstudiantesPorPadre_Result> obtenerHijosPorPadreLN(int idPadre);
    }
}
