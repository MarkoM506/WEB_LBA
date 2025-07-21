using System.ComponentModel.DataAnnotations;

namespace WEB_LBA.Models
{
    public class M_Profesor
    {
        [Display(Name = "ID del Profesor")]
        public int id_profesor { get; set; }

        [Required(ErrorMessage = "La cédula es requerida")]
        [MinLength(9, ErrorMessage = "Debe tener al menos 9 caracteres")]
        [Display(Name = "Cédula")]
        public string cedula { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [MinLength(3, ErrorMessage = "Debe tener al menos 3 caracteres")]
        [Display(Name = "Nombre completo")]
        public string nombre { get; set; }
    }
}
