using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WEB_LBA.Models
{
    public class M_Seccion
    {

        [Required(ErrorMessage = "EL id de la Sección es requerido")]
        [Display(Name = "ID de Sección")]
        public int id_seccion { get; set; }

        [Required(ErrorMessage = "El nombre de la Sección es requerido")]
        [Display(Name = "Nombre de Sección")]

        [MinLength(3, ErrorMessage = "El nombre de Sección debe contener al menos 3 carácteres")]
        public string nombre_seccion { get; set; }

        [Required(ErrorMessage = "EL id del ciclo es requerido")]
        [Display(Name = "ID del Ciclo")]

        public Nullable<int> id_ciclo { get; set; }
    }
}