using System;
using LogicaNegocio.Interfaces;
using AccesoDatos;
using AccesoDatos.Interfaces;

namespace LogicaNegocio
{
    public class MatriculaLN : IMatriculaLN
    {
        private MatriculaAD matriculaAD = new MatriculaAD();

        public bool insertarMatriculaLN(string nombreEst, string cedulaEst, string escuela, DateTime fechaNac,
                                        string telEst, string nivel, string nombrePadre, string cedulaPadre,
                                        string telPadre, string direccionPadre, string parentesco,
                                        DateTime fechaCita, string horaCita)
        {
            try
            {
                return matriculaAD.insertarMatriculaAD(nombreEst, cedulaEst, escuela, fechaNac,
                                                       telEst, nivel, nombrePadre, cedulaPadre,
                                                       telPadre, direccionPadre, parentesco,
                                                       fechaCita, horaCita);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}