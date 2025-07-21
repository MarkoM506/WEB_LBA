using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB_LBA.Models
{
    public class M_MateriaConsulta
    {
        public int id_materia { get; set; }
        public string nombre_materia { get; set; }
        public string profesores { get; set; } // STRING_AGG en SP
    }
}