using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WEB_LBA.Models
{
    public class M_Asistencia
    {

        public int id_asistencia { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un estudiante.")]
        [Display(Name = "Estudiante")]
        public int id_estudiante { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una materia.")]
        [Display(Name = "Materia")]
        public int id_materia { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un profesor.")]
        [Display(Name = "Profesor")]
        public int id_profesor { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un estado.")]
        [Display(Name = "Estado")]
        public int id_estado { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria.")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha")]
        public DateTime fecha { get; set; }

        [Display(Name = "Observaciones")]
        public string observaciones { get; set; }
    }
}