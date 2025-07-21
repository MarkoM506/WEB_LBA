using System.ComponentModel.DataAnnotations;

namespace WEB_LBA.Models
{
    public class M_ProfesorPorMateria
    {
        [Display(Name = "ID de la Materia")]
        public int id_materia { get; set; }

        [Display(Name = "Nombre de la Materia")]
        public string nombre_materia { get; set; }

        [Display(Name = "ID del Profesor")]
        public int id_profesor { get; set; }

        [Display(Name = "Nombre del Profesor")]
        public string nombre_profesor { get; set; }
    }
}
