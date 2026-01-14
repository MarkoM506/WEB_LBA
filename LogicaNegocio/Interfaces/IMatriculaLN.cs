using System;

namespace LogicaNegocio.Interfaces
{
    public interface IMatriculaLN
    {
        bool insertarMatriculaLN(string nombreEst, string cedulaEst, string escuela, DateTime fechaNac,
                                 string telEst, string nivel, string nombrePadre, string cedulaPadre,
                                 string telPadre, string direccionPadre, string parentesco,
                                 DateTime fechaCita, string horaCita);
    }
}