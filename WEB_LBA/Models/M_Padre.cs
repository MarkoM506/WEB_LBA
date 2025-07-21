using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WEB_LBA.Models
{
    public class M_Padre
    {
        [Display(Name = "ID del Padre")]
        public int id_padre { get; set; }

        [Required(ErrorMessage = "La cédula es requerida")]
        [MinLength(9, ErrorMessage = "Debe tener al menos 9 caracteres")]
        [Display(Name = "Cédula")]
        public string cedula { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [MinLength(3, ErrorMessage = "Debe tener al menos 3 caracteres")]
        [Display(Name = "Nombre completo")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "El teléfono es requerido")]
        [Display(Name = "Teléfono")]
        public string telefono { get; set; }
    }
}