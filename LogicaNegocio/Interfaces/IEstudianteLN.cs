using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Interfaces
{
    public interface IEstudianteLN
    {
        List<SP_recEstudiantes_Result> recEstudianteln();

        List<SP_recEstudiantesPorSeccion_Result> recEstudiantesPorSeccionln(int idSeccion);
        List<SP_recPadresPorEstudiante_Result> obtenerPadresPorEstudianteLN(int idEstudiante);
        SP_recEstudiantePorCedula_Result recEstudiantePorCedulaln(string cedula);

        SP_recEstudiantePorId_Result recEstudianteXIdln(int pId);

        bool insEstudianteln(Estudiante pobjEstudiante);

        bool modEstudianteln(Estudiante pobjEstudiante);

        bool delEstudianteln(Estudiante pobjEstudiante);


    }
}
