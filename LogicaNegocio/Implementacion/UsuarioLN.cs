using System;
using System.Collections.Generic;
using AccesoDatos;
using AccesoDatos.Interfaces;
using Entidades;
using LogicaNegocio.Interfaces;
using WEB_LBA.AccesoDatos;

namespace LogicaNegocio
{
    public class UsuarioLN : IUsuarioLN
    {
        private static  L_BAEntities  contexto = new L_BAEntities();
        private UsuarioAD usuarioAD = new UsuarioAD();

        public List<SP_recUsuarios_Result> recUsuariosLN()
        {
            try
            {
                return usuarioAD.recUsuarios();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public SP_recUsuarioPorId_Result recUsuarioPorIdLN(int id)
        {
            try
            {
                return usuarioAD.recUsuarioPorId(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void insUsuarioLN(string usuario, string contrasena, string rol, int? id_estudiante, int? id_profesor)
        {
            try
            {
                usuarioAD.insUsuario(usuario, contrasena, rol, id_estudiante, id_profesor);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void modUsuarioLN(int id_usuario, string usuario, string contrasena, string rol, bool activo)
        {
            try
            {
                usuarioAD.modUsuario(id_usuario, usuario, contrasena, rol, activo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void delUsuarioLN(int id_usuario)
        {
            try
            {
                usuarioAD.delUsuario(id_usuario);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public SP_loginUsuario_Result loginUsuarioLN(string usuario, string contrasena)
        {
            try
            {
                return usuarioAD.loginUsuariO(usuario, contrasena);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}