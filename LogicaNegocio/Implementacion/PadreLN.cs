using AccesoDatos;
using AccesoDatos.Implementacion;
using AccesoDatos.Interfaces;
using Entidades;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;

namespace LogicaNegocio.Implementacion
{
    public class PadreLN : IPadreLN
    {
        private readonly IPadreAD gobjPadreAD;

        public PadreLN()
        {
            gobjPadreAD = new PadreAD(new BD_LBAEntities());
        }

        // CRUD
        public List<SP_recPadres_Result> recPadresLN()
        {
            return gobjPadreAD.recPadres();
        }

        public SP_recPadrePorId_Result recPadrePorIdLN(int id)
        {
            return gobjPadreAD.recPadrePorId(id);
        }

        public SP_recPadrePorCedula_Result recPadrePorCedulaLN(string cedula)
        {
            return gobjPadreAD.recPadrePorCedula(cedula);
        }

        public bool insPadreLN(Padre padre)
        {
            return gobjPadreAD.insPadrE(padre);
        }

        public bool modPadreLN(Padre padre)
        {
            return gobjPadreAD.modPadrE(padre);
        }

        public bool delPadreLN(Padre padre)
        {
            return gobjPadreAD.delPadrE(padre);
        }

        // Relación Padre - Estudiantes
        public bool asignarEstudianteALN(int idPadre, int idEstudiante)
        {
            return gobjPadreAD.asignarEstudiante(idPadre, idEstudiante);
        }

        public bool quitarEstudianteDeLN(int idPadre, int idEstudiante)
        {
            return gobjPadreAD.quitarEstudiante(idPadre, idEstudiante);
        }

        public List<SP_recEstudiantesPorPadre_Result> obtenerHijosPorPadreLN(int idPadre)
        {
            return gobjPadreAD.obtenerHijosPorPadre(idPadre);
        }
    }
}
