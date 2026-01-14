using System;
using System.ComponentModel.DataAnnotations;

namespace WEB_LBA.Models
{
    public class M_MatriculaMEP
    {
        [Display(Name = "Nombre del Estudiante")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string nombre_estudiante { get; set; }

        [Display(Name = "Cédula del Estudiante")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string cedula_estudiante { get; set; }

        [Display(Name = "Escuela de Procedencia")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string escuela_procedencia { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public DateTime fecha_nacimiento { get; set; } = DateTime.Today;

        [Display(Name = "Teléfono del Estudiante")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string telefono_estudiante { get; set; }

        [Display(Name = "Nivel")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string nivel { get; set; }

        [Display(Name = "Nombre del Encargado")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string nombre_padre { get; set; }

        [Display(Name = "Cédula del Encargado")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string cedula_padre { get; set; }

        [Display(Name = "Teléfono del Encargado")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string telefono_padre { get; set; }

        [Display(Name = "Dirección del Encargado")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string direccion_padre { get; set; }

        [Display(Name = "Parentesco con el Estudiante")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string parentesco { get; set; }

        [Display(Name = "Fecha de la Cita")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public DateTime fecha_cita { get; set; } = DateTime.Today;

        [Display(Name = "Hora de la Cita")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string hora_cita { get; set; }
    }
}