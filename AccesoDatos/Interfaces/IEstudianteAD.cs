using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaces
{
    public interface IEstudianteAD
    {
        List<SP_recEstudiantes_Result> recEstudiantee();

        List<SP_recEstudiantesPorSeccion_Result> recEstudiantesXSeccion(int idSeccion);
        List<SP_recPadresPorEstudiante_Result> obtenerPadresPorEstudiante(int idEstudiante);

        SP_recEstudiantePorCedula_Result recEstudianteXCedula(string cedula);

        SP_recEstudiantePorId_Result recEstudianteXId(int pId);

        bool insEstudiantee(Estudiante pobjEstudiante);

        bool modEstudiantee(Estudiante pobjEstudiante);

        bool delEstudiantee(Estudiante pobjEstudiante);
    }
}
