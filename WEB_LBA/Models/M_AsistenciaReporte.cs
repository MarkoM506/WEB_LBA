using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WEB_LBA.Models
{
    public class M_AsistenciaReporte
    {
        [Required(ErrorMessage = "El año es obligatorio.")]
        [Range(2020, 2100, ErrorMessage = "El año debe estar entre 2020 y 2100.")]
        [Display(Name = "Año")]
        public int anio { get; set; }

        [Required(ErrorMessage = "El mes es obligatorio.")]
        [Range(1, 12, ErrorMessage = "El mes debe estar entre 1 y 12.")]
        [Display(Name = "Mes")]
        public int mes { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un profesor.")]
        [Display(Name = "Profesor")]
        public int id_profesor { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una sección.")]
        [Display(Name = "Sección")]
        public int id_seccion { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una materia.")]
        [Display(Name = "Materia")]
        public int id_materia { get; set; }

        [Display(Name = "Días en el mes")]
        public int diasEnElMes
        {
            get
            {
                if (mes >= 1 && mes <= 12 && anio > 0)
                    return DateTime.DaysInMonth(anio, mes);
                return 0;
            }
        }

        public List<ReporteAsistenciaMensualDTO> resultado { get; set; }

        // ✅ Constructor para evitar null
        public M_AsistenciaReporte()
        {
            resultado = new List<ReporteAsistenciaMensualDTO>();
        }
    }
}