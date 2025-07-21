using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB_LBA.Models
{
    public class M_NotaConsulta
    {
        public int id_nota { get; set; }
        public string estudiante { get; set; }
        public string materia { get; set; }
        public string profesor { get; set; }
        public string tipo_nota { get; set; }
        public decimal nota { get; set; }
        public string observaciones { get; set; }
        public DateTime fecha { get; set; }
    }
}