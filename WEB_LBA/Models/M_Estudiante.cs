using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WEB_LBA.Models
{
    public class M_Estudiante
    {

        [Display(Name = "ID del Estudiante")]
        public int id_estudiante { get; set; }


        [Required(ErrorMessage = "El número de cédula es requerido")]
        [Display(Name = "Numero de Cédula\n" +
            "(Con ceros)")]

        [MinLength(9, ErrorMessage = "El número de Cédula debe contener al menos 9 carácteres")]
        public string cedula { get; set; }

        [Required(ErrorMessage = "El nombre del Estudiante es requerido")]
        [Display(Name = "Nombre del Estudiante\n" +
            "(Con Apellidos)")]

        [MinLength(3, ErrorMessage = "El nombre del Estudiante debe contener al menos 3 carácteres")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "La Dirección del Estudiante es requerida")]
        [Display(Name = "Dirección")]

        [MinLength(3, ErrorMessage = "la Dirección debe contener al menos 3 carácteres")]
        public string direccion { get; set; }

        [Required(ErrorMessage = "El número de teléfono es requerido")]
        [Display(Name = "Número de teléfono")]

        [MinLength(8, ErrorMessage = "El número debe contener al menos 8 carácteres")]
        public string telefono { get; set; }


        [Required(ErrorMessage = "EL id de la Sección es requerido")]
        [Display(Name = "ID de Sección")]

        public Nullable<int> id_seccion { get; set; }



    }
}