using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WEB_LBA.Models
{
    public class M_PadreConsulta
    {
        [Required(ErrorMessage = "El ID del padre es requerido")]
        [Display(Name = "ID del Padre")]
        public int id_padre { get; set; }

        [Required(ErrorMessage = "La cédula del padre es requerida")]
        [Display(Name = "Cédula")]
        [MinLength(9, ErrorMessage = "La cédula debe tener al menos 9 caracteres")]
        public string cedula { get; set; }

        [Required(ErrorMessage = "El nombre del padre es requerido")]
        [Display(Name = "Nombre del Padre")]
        [MinLength(3, ErrorMessage = "El nombre debe tener al menos 3 caracteres")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "El teléfono del padre es requerido")]
        [Display(Name = "Teléfono")]
        [MinLength(8, ErrorMessage = "El teléfono debe tener al menos 8 caracteres")]
        public string telefono { get; set; }
    }
}