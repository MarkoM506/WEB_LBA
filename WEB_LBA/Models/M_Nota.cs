using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB_LBA.Models
{
    public class M_Nota
    {
        public int id_nota { get; set; }
        public int id_estudiante { get; set; }
        public int id_materia { get; set; }
        public int id_profesor { get; set; }
        public int id_tipo_nota { get; set; }
        public decimal nota { get; set; }
        public string observaciones { get; set; }
        public DateTime fecha { get; set; }
    }
}