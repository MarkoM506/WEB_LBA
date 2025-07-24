using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WEB_LBA.Models
{
    public class M_Noticia
    {
        public int id_noticia { get; set; }

        [Required(ErrorMessage = "El título es obligatorio")]
        [Display(Name = "Título")]
        [StringLength(200, ErrorMessage = "El título no debe superar los 200 caracteres")]
        public string titulo { get; set; }

        [Required(ErrorMessage = "El contenido es obligatorio")]
        [Display(Name = "Contenido")]
        [DataType(DataType.MultilineText)]
        public string contenido { get; set; }

        [Required(ErrorMessage = "Debe indicar la fecha de publicación")]
        [Display(Name = "Fecha de Publicación")]
        [DataType(DataType.Date)]
        public DateTime fecha_publicacion { get; set; }

        [Display(Name = "URL de la Imagen")]
        [StringLength(300)]
        public string imagen_url { get; set; }

        public HttpPostedFileBase ImagenSubida { get; set; } // 👈 nuevo
    }
}
