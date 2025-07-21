using AccesoDatos;
using AccesoDatos.Implementacion;
using AccesoDatos.Interfaces;
using Entidades;
using LogicaNegocio.Interfaces;
using System.Collections.Generic;

namespace LogicaNegocio.Implementacion
{
    public class MateriaLN : IMateriaLN
    {
        private IMateriaAD gobjMateriaAD;

        public MateriaLN()
        {
            gobjMateriaAD = new MateriaAD(new L_BAEntities());
        }

        public MateriaLN(L_BAEntities contexto)
        {
            gobjMateriaAD = new MateriaAD(contexto);
        }

        public List<SP_recMaterias_Result> recMateriasln()
        {
            return gobjMateriaAD.recMateriaS();
        }

        public List<SP_recMateriasConProfesores_Result> recMateriasConProfesln()
        {
            return gobjMateriaAD.recMateriasConProfes();
        }

        public SP_recMateriaPorId_Result recMateriaXIdln(int idMateria)
        {
            return gobjMateriaAD.recMateriaXId(idMateria);
        }

        public bool insMaterialn(Materia materia)
        {
            return gobjMateriaAD.insMateriA(materia);
        }

        public bool modMaterialn(Materia materia)
        {
            return gobjMateriaAD.modMateriA(materia);
        }

        public bool delMaterialn(Materia materia)
        {
            return gobjMateriaAD.delMateriA(materia);
        }
    }
}
