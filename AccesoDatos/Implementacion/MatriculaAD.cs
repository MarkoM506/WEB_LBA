using System;
using System.Data.Entity;
using AccesoDatos;
using AccesoDatos.Interfaces;

namespace AccesoDatos
{
    public class MatriculaAD : IMatriculaAD
    {
        public bool insertarMatriculaAD(string nombreEst, string cedulaEst, string escuela, DateTime fechaNac,
                                        string telEst, string nivel, string nombrePadre, string cedulaPadre,
                                        string telPadre, string direccionPadre, string parentesco,
                                        DateTime fechaCita, string horaCita)
        {
            using (L_BAEntities contexto = new L_BAEntities())
            {
                contexto.Configuration.ProxyCreationEnabled = false;
                contexto.SP_insMatricula(nombreEst, cedulaEst, escuela, fechaNac,
                                         telEst, nivel, nombrePadre, cedulaPadre,
                                         telPadre, direccionPadre, parentesco,
                                         fechaCita, horaCita);
                return true;
            }
        }
    }
}