using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Interfaces
{
    public interface IProfesorLN
    {
        List<SP_recProfesores_Result> recProfesoresLN();

        SP_recProfesorPorId_Result recProfesorXIdLN(int pId);

        bool insProfesorLN(Profesore pobjProfesor);

        bool modProfesorLN(Profesore pobjProfesor);

        bool delProfesorLN(Profesore pobjProfesor);

        List<SP_recMateriasPorProfesor_Result> obtenerMateriasPorProfesorLN(int idProfesor);

        List<SP_recProfesoresPorMateria_Result> obtenerProfesoresPorMateriaLN(int idMateria);

        List<SP_recProfesoresConMaterias_Result> listarProfesoresConMateriasLN();

        bool vincularMateriaAProfesorLN(int idProfesor, int idMateria);

        bool removerMateriaDeProfesorLN(int idProfesor, int idMateria);
    }
}
