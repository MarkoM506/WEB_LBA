using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WEB_LBA.Models
{
    public class M_Materia
    {
        public int id_materia { get; set; }

        [Required(ErrorMessage = "El nombre de la materia es obligatorio.")]
        [StringLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        [Display(Name = "Nombre de la Materia")]
        public string nombre_materia { get; set; }

        [Display(Name = "Profesores Asignados")]
        public List<int> profesores_seleccionados { get; set; } = new List<int>();
    }
}