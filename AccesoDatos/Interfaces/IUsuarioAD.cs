using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaces
{
    public interface IUsuarioAD
    {
        List<SP_recUsuarios_Result> recUsuarios();
        SP_recUsuarioPorId_Result recUsuarioPorId(int id);
        void insUsuario(string usuario, string contrasena, string rol, int? id_estudiante, int? id_profesor);
        void modUsuario(int id, string usuario, string contrasena, string rol, bool activo);
        void delUsuario(int id);
        SP_loginUsuario_Result loginUsuariO(string usuario, string contrasena);
    }
}
