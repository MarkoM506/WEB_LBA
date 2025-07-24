using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WEB_LBA.Models
{
    public class M_Contacto
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string nombre { get; set; }
        [Display(Name = "Su correo Electrónico")]
        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "Ingrese un correo válido.")]
        public string correo { get; set; }

        [Required(ErrorMessage = "El asunto es obligatorio.")]
        public string asunto { get; set; }

        [Required(ErrorMessage = "Debe escribir un mensaje.")]
        public string mensaje { get; set; }
    }
}