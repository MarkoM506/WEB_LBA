using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WEB_LBA.Models
{
    public class M_Ciclo
    {
        [Required(ErrorMessage = "EL id del ciclo es requerido")]
        [Display(Name = "ID del Ciclo")]
        public int id_ciclo { get; set; }


        [Required(ErrorMessage = "El nombre del Ciclo es requerido")]
        [Display(Name = "Nombre del Ciclo")]

        [MinLength(3, ErrorMessage = "El nombre del Ciclo debe contener al menos 3 carácteres")]
        public string nombre_ciclo { get; set; }

        [Required(ErrorMessage = "La descripción del ciclo es requerido")]
        [Display(Name = "Descripción del Ciclo")]

        [MinLength(10, ErrorMessage = "La descripción del Ciclo debe contener al menos 10 carácteres")]
        public string descripcion { get; set; }
    }
}