using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaces
{
    public interface IProfesorAD
    {
        List<SP_recProfesores_Result> recProfesoreS();

        SP_recProfesorPorId_Result recProfesoresXId(int pId);

        bool insProfesores(Profesore pobjProfe);

        bool modProfesores(Profesore pobjProfe);

        bool delProfesores(Profesore pobjProfe);

        List<SP_recMateriasPorProfesor_Result> obtenerMateriasPorProfesor(int idProfesor);

        List<SP_recProfesoresPorMateria_Result> obtenerProfesoresPorMateria(int idMateria);

        List<SP_recProfesoresConMaterias_Result> listarProfesoresConMaterias();

        bool vincularMateriaAProfesor(int idProfesor, int idMateria);

        bool removerMateriaDeProfesor(int idProfesor, int idMateria);

    }
}
