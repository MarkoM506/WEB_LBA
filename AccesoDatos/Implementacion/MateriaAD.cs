using AccesoDatos.Interfaces;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccesoDatos.Implementacion
{
    public class MateriaAD : IMateriaAD
    {
        private L_BAEntities gobjContextoLBA;

        public MateriaAD(L_BAEntities _gobjContexto)
        {
            this.gobjContextoLBA = _gobjContexto;
        }

        public List<SP_recMaterias_Result> recMateriaS()
        {
            return gobjContextoLBA.SP_recMaterias().ToList();
        }

        public List<SP_recMateriasConProfesores_Result> recMateriasConProfes()
        {
            return gobjContextoLBA.SP_recMateriasConProfesores().ToList();
        }

        public SP_recMateriaPorId_Result recMateriaXId(int pId)
        {
            return gobjContextoLBA.SP_recMateriaPorId(pId).Single();
        }

        public bool insMateriA(Materia pobjMateria)
        {
            var proxy = gobjContextoLBA.Configuration.ProxyCreationEnabled;
            gobjContextoLBA.Configuration.ProxyCreationEnabled = false;
            bool respuesta = false;

            try
            {
                int resultado = gobjContextoLBA.SP_insMateria(pobjMateria.nombre_materia);
                respuesta = resultado == 1;
            }
            finally
            {
                gobjContextoLBA.Configuration.ProxyCreationEnabled = proxy;
            }

            return respuesta;
        }

        public bool modMateriA(Materia pobjMateria)
        {
            var proxy = gobjContextoLBA.Configuration.ProxyCreationEnabled;
            gobjContextoLBA.Configuration.ProxyCreationEnabled = false;
            bool respuesta = false;

            try
            {
                int resultado = gobjContextoLBA.SP_modMateria(pobjMateria.id_materia, pobjMateria.nombre_materia);
                respuesta = resultado == 1;
            }
            finally
            {
                gobjContextoLBA.Configuration.ProxyCreationEnabled = proxy;
            }

            return respuesta;
        }

        public bool delMateriA(Materia pobjMateria)
        {
            var proxy = gobjContextoLBA.Configuration.ProxyCreationEnabled;
            gobjContextoLBA.Configuration.ProxyCreationEnabled = false;
            bool respuesta = false;

            try
            {
                int resultado = gobjContextoLBA.SP_delMateria(pobjMateria.id_materia);
                respuesta = resultado == 1;
            }
            finally
            {
                gobjContextoLBA.Configuration.ProxyCreationEnabled = proxy;
            }

            return respuesta;
        }
    }
}
