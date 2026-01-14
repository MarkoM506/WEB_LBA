using System;

namespace AccesoDatos.Interfaces
{
    public interface IMatriculaAD
    {
        bool insertarMatriculaAD(string nombreEst, string cedulaEst, string escuela, DateTime fechaNac,
                                 string telEst, string nivel, string nombrePadre, string cedulaPadre,
                                 string telPadre, string direccionPadre, string parentesco,
                                 DateTime fechaCita, string horaCita);
    }
}