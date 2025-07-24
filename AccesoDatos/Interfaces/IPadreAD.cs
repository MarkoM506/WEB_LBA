using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaces
{
    public interface IPadreAD
    {
        // CRUD

        List<SP_recPadres_Result> recPadres();
        SP_recPadrePorId_Result recPadrePorId(int id);
        SP_recPadrePorCedula_Result recPadrePorCedula(string cedula);

        List<SP_recEstudiantesPorPadre_Result> obtenerHijosPorPadre(int idPadre);

        bool asignarEstudiante(int idPadre, int idEstudiante);

        bool quitarEstudiante(int idPadre, int idEstudiante);


        bool insPadrE(Padre padre);
        bool modPadrE(Padre padre);
        bool delPadrE(Padre padre);

        // Relación Padre - Estudiantes
     
        
    }
}
