using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Interfaces
{
    public interface IUsuarioLN
    {
        List<SP_recUsuarios_Result> recUsuariosLN();

        SP_recUsuarioPorId_Result recUsuarioPorIdLN(int id_usuario);

        void insUsuarioLN(string usuario, string contrasena, string rol, int? id_estudiante = null, int? id_profesor = null);

        void modUsuarioLN(int id_usuario, string usuario, string contrasena, string rol, bool activo);

        void delUsuarioLN(int id_usuario);

        SP_loginUsuario_Result loginUsuarioLN(string usuario, string contrasena);
    }
}
