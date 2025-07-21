using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.Interfaces;
using Entidades;



namespace AccesoDatos.Implementacion
{
    public class MatriculaAD : IMatriculaMEPAD
    {
        private readonly L_BAEntities contexto;

        public MatriculaAD()
        {
            contexto = new L_BAEntities();
            contexto.Configuration.ProxyCreationEnabled = false;
        }

        public void insMatricula(
            string nombre_estudiante,
            string cedula_estudiante,
            DateTime fecha_nacimiento,
            string genero,
            string nacionalidad_estudiante,
            string lugar_nacimiento,
            string tipo_agrupamiento,
            string modalidad_ingreso,
            string escuela_procedencia,
            string distrito_donde_vive,
            string pueblo_donde_vive,
            string telefono_estudiante,
            string correo_electronico_estudiante,
            string nivel_academico,
            string grado_academico,
            string modalidad_academica,
            bool recibe_ayuda_economica,
            string tipo_ayuda,

            string nombre_madre,
            string cedula_madre,
            string nacionalidad_madre,
            string telefono_madre,
            string escolaridad_madre,
            string direccion_madre,

            string nombre_padre,
            string cedula_padre,
            string nacionalidad_padre,
            string telefono_padre,
            string escolaridad_padre,
            string direccion_padre,

            bool permiso_educacion_religiosa,
            bool permiso_salidas_libres,
            bool permiso_imagenes,
            bool permiso_autoriza_otro_retirar,

            string comentario_adicional,
            string firma_padre_madre,
            string cedula_firma,
            string nombre_funcionario,
            DateTime fecha_firma
        )
        {
            contexto.SP_insMatricula(
                nombre_estudiante, cedula_estudiante, fecha_nacimiento, genero, nacionalidad_estudiante,
                lugar_nacimiento, tipo_agrupamiento, modalidad_ingreso, escuela_procedencia, distrito_donde_vive,
                pueblo_donde_vive, telefono_estudiante, correo_electronico_estudiante, nivel_academico, grado_academico,
                modalidad_academica, recibe_ayuda_economica, tipo_ayuda,

                nombre_madre, cedula_madre, nacionalidad_madre, telefono_madre, escolaridad_madre, direccion_madre,

                nombre_padre, cedula_padre, nacionalidad_padre, telefono_padre, escolaridad_padre, direccion_padre,

                permiso_educacion_religiosa, permiso_salidas_libres, permiso_imagenes, permiso_autoriza_otro_retirar,

                comentario_adicional, firma_padre_madre, cedula_firma, nombre_funcionario, fecha_firma
            );
        }
    }
}
