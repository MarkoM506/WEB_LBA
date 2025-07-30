using AccesoDatos.Interfaces;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccesoDatos.Implementacion
{
    public class PadreAD : IPadreAD
    {
        private L_BAEntities gobjContextoLBA;

        public PadreAD(L_BAEntities contexto)
        {   
            gobjContextoLBA = contexto;
        }

        // CRUD Padres
        public List<SP_recPadres_Result> recPadres()
        {
            return gobjContextoLBA.SP_recPadres().ToList();
        }

        public SP_recPadrePorId_Result recPadrePorId(int id)
        {
            return gobjContextoLBA.SP_recPadrePorId(id).FirstOrDefault();
        }

        public SP_recPadrePorCedula_Result recPadrePorCedula(string cedula)
        {
            return gobjContextoLBA.SP_recPadrePorCedula(cedula).FirstOrDefault();
        }

        public bool insPadrE(Padre padre)
        {
            bool respuesta = false;
            var proxy = gobjContextoLBA.Configuration.ProxyCreationEnabled;

            try
            {
                gobjContextoLBA.Configuration.ProxyCreationEnabled = false;
                int result = gobjContextoLBA.SP_insPadre(padre.cedula, padre.nombre, padre.telefono);
                respuesta = result == 1;
            }
            finally
            {
                gobjContextoLBA.Configuration.ProxyCreationEnabled = proxy;
            }

            return respuesta;
        }

        public bool modPadrE(Padre padre)
        {
            bool respuesta = false;
            var proxy = gobjContextoLBA.Configuration.ProxyCreationEnabled;

            try
            {
                gobjContextoLBA.Configuration.ProxyCreationEnabled = false;
                int result = gobjContextoLBA.SP_modPadre(padre.id_padre, padre.cedula, padre.nombre, padre.telefono);
                respuesta = result == 1;
            }
            finally
            {
                gobjContextoLBA.Configuration.ProxyCreationEnabled = proxy;
            }

            return respuesta;
        }

        public bool delPadrE(Padre padre)
        {
            bool respuesta = false;
            var proxy = gobjContextoLBA.Configuration.ProxyCreationEnabled;

            try
            {
                gobjContextoLBA.Configuration.ProxyCreationEnabled = false;
                int result = gobjContextoLBA.SP_delPadre(padre.id_padre);
                respuesta = result == 1;
            }
            finally
            {
                gobjContextoLBA.Configuration.ProxyCreationEnabled = proxy;
            }

            return respuesta;
        }

        // =============================
        // RELACIÓN Padres - Estudiantes
        // =============================

        public bool asignarEstudiante(int idPadre, int idEstudiante)
        {
            try
            {
                gobjContextoLBA.SP_asignarEstudianteAPadre(idPadre, idEstudiante);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool quitarEstudiante(int idPadre, int idEstudiante)
        {
            try
            {
                gobjContextoLBA.SP_quitarEstudianteDePadre(idPadre, idEstudiante);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<SP_recEstudiantesPorPadre_Result> obtenerHijosPorPadre(int idPadre)
        {
            return gobjContextoLBA.SP_recEstudiantesPorPadre(idPadre).ToList();
        }
    }
}