using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;
using Entidades;
namespace WEB_LBA.Models
{
    public class M_MatriculaMEP
    {
        // Estudiante
        [Required(ErrorMessage = "El nombre del estudiante es obligatorio.")]
        [MinLength(5, ErrorMessage = "Debe tener al menos 5 caracteres.")]
        [Display(Name = "Nombre del estudiante")]
        public string nombre_estudiante { get; set; }

        [Required(ErrorMessage = "La cédula del estudiante es obligatoria.")]
        [Display(Name = "Cédula del estudiante")]
        public string cedula_estudiante { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
        [Display(Name = "Fecha de nacimiento")]
        public DateTime fecha_nacimiento { get; set; }

        [Required(ErrorMessage = "El género es obligatorio.")]
        [Display(Name = "Género")]
        public string genero { get; set; }

        [Required(ErrorMessage = "La nacionalidad es obligatoria.")]
        [Display(Name = "Nacionalidad del estudiante")]
        public string nacionalidad_estudiante { get; set; }

        [Required(ErrorMessage = "El lugar de nacimiento es obligatorio.")]
        [Display(Name = "Lugar de nacimiento")]
        public string lugar_nacimiento { get; set; }

        [Required(ErrorMessage = "El tipo de agrupamiento es obligatorio.")]
        [Display(Name = "Tipo de agrupamiento")]
        public string tipo_agrupamiento { get; set; }

        [Required(ErrorMessage = "La modalidad de ingreso es obligatoria.")]
        [Display(Name = "Modalidad de ingreso")]
        public string modalidad_ingreso { get; set; }

        [Display(Name = "Escuela de procedencia")]
        public string escuela_procedencia { get; set; }

        [Required(ErrorMessage = "El distrito donde vive es obligatorio.")]
        [Display(Name = "Distrito donde vive")]
        public string distrito_donde_vive { get; set; }

        [Required(ErrorMessage = "El pueblo donde vive es obligatorio.")]
        [Display(Name = "Pueblo donde vive")]
        public string pueblo_donde_vive { get; set; }

        [Phone(ErrorMessage = "Teléfono no válido.")]
        [Display(Name = "Teléfono del estudiante")]
        public string telefono_estudiante { get; set; }

        [EmailAddress(ErrorMessage = "Correo no válido.")]
        [Display(Name = "Correo electrónico del estudiante")]
        public string correo_electronico_estudiante { get; set; }

        [Required(ErrorMessage = "El nivel académico es obligatorio.")]
        [Display(Name = "Nivel académico")]
        public string nivel_academico { get; set; }

        [Required(ErrorMessage = "El grado académico es obligatorio.")]
        [Display(Name = "Grado académico")]
        public string grado_academico { get; set; }

        [Required(ErrorMessage = "La modalidad académica es obligatoria.")]
        [Display(Name = "Modalidad académica")]
        public string modalidad_academica { get; set; }

        [Display(Name = "¿Recibe ayuda económica?")]
        public bool recibe_ayuda_economica { get; set; }

        [Display(Name = "Tipo de ayuda económica")]
        public string tipo_ayuda { get; set; }

        // Madre
        [Required(ErrorMessage = "El nombre de la madre es obligatorio.")]
        [Display(Name = "Nombre de la madre")]
        public string nombre_madre { get; set; }

        [Display(Name = "Cédula de la madre")]
        public string cedula_madre { get; set; }

        [Display(Name = "Nacionalidad de la madre")]
        public string nacionalidad_madre { get; set; }

        [Phone(ErrorMessage = "Teléfono no válido.")]
        [Display(Name = "Teléfono de la madre")]
        public string telefono_madre { get; set; }

        [Display(Name = "Escolaridad de la madre")]
        public string escolaridad_madre { get; set; }

        [Display(Name = "Dirección de la madre")]
        public string direccion_madre { get; set; }

        // Padre
        [Display(Name = "Nombre del padre")]
        public string nombre_padre { get; set; }

        [Display(Name = "Cédula del padre")]
        public string cedula_padre { get; set; }

        [Display(Name = "Nacionalidad del padre")]
        public string nacionalidad_padre { get; set; }

        [Phone(ErrorMessage = "Teléfono no válido.")]
        [Display(Name = "Teléfono del padre")]
        public string telefono_padre { get; set; }

        [Display(Name = "Escolaridad del padre")]
        public string escolaridad_padre { get; set; }

        [Display(Name = "Dirección del padre")]
        public string direccion_padre { get; set; }

        // Permisos
        [Display(Name = "Autoriza educación religiosa")]
        public bool permiso_educacion_religiosa { get; set; }

        [Display(Name = "Autoriza salidas libres")]
        public bool permiso_salidas_libres { get; set; }

        [Display(Name = "Autoriza uso de imagen")]
        public bool permiso_imagenes { get; set; }

        [Display(Name = "Autoriza que otra persona retire")]
        public bool permiso_autoriza_otro_retirar { get; set; }

        // Comentarios y firma
        [Display(Name = "Comentario adicional")]
        public string comentario_adicional { get; set; }

        [Required(ErrorMessage = "La firma del padre o madre es obligatoria.")]
        [Display(Name = "Firma del padre/madre")]
        public string firma_padre_madre { get; set; }

        [Display(Name = "Cédula del firmante")]
        public string cedula_firma { get; set; }

        [Required(ErrorMessage = "Debe ingresar el nombre del funcionario.")]
        [Display(Name = "Funcionario que recibe")]
        public string nombre_funcionario { get; set; }

        [Display(Name = "Fecha de la firma")]
        public DateTime? fecha_firma { get; set; } 
    }
}