using AccesoDatos;
using AccesoDatos.Interfaces;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;


namespace WEB_LBA.AccesoDatos
{
    public class UsuarioAD : IUsuarioAD
    {
        private L_BAEntities contexto;

        public UsuarioAD()
        {
            contexto = new L_BAEntities();
            contexto.Configuration.ProxyCreationEnabled = false;
        }

        public List<SP_recUsuarios_Result> recUsuarios()
        {
            try
            {
                return contexto.SP_recUsuarios().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar los usuarios: " + ex.Message);
            }
        }

        public SP_recUsuarioPorId_Result recUsuarioPorId(int id)
        {
            try
            {
                return contexto.SP_recUsuarioPorId(id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar el usuario por ID: " + ex.Message);
            }
        }

        public void insUsuario(string usuario, string contrasena, string rol, int? id_estudiante, int? id_profesor)
        {
            try
            {
                contexto.SP_insUsuario(usuario, contrasena, rol, id_estudiante, id_profesor);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar usuario: " + ex.Message);
            }
        }

        public void modUsuario(int id, string usuario, string contrasena, string rol, bool activo)
        {
            try
            {
                contexto.SP_modUsuario(id, usuario, contrasena, rol, activo);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar usuario: " + ex.Message);
            }
        }

        public void delUsuario(int id)
        {
            try
            {
                contexto.SP_delUsuario(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar usuario: " + ex.Message);
            }
        }

        public SP_loginUsuario_Result loginUsuariO(string usuario, string contrasena)
        {
            try
            {
                return contexto.SP_loginUsuario(usuario, contrasena).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al validar login: " + ex.Message);
            }
        }
    }
}