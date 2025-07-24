using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WEB_LBA.Models
{
    public class M_Usuario
    {

        public int id_usuario { get; set; }

        [Required(ErrorMessage = "El nombre de usuario es obligatorio")]
        [MinLength(4, ErrorMessage = "El usuario debe tener al menos 4 caracteres")]
        [MaxLength(50, ErrorMessage = "El usuario no debe exceder 50 caracteres")]
        [Display(Name = "Usuario")]
        public string usuario { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [MinLength(6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres")]
        [MaxLength(100, ErrorMessage = "La contraseña no debe exceder 100 caracteres")]
        [Display(Name = "Contraseña")]
        public string contrasena { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un rol")]
        [Display(Name = "Rol")]
        public string rol { get; set; }

        [Display(Name = "ID Estudiante")]
        public int? id_estudiante { get; set; }

        [Display(Name = "ID Profesor")]
        public int? id_profesor { get; set; }

        public bool activo { get; set; }


    }
}