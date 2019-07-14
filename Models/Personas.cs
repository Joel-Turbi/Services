using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Newtech.Models
{
    public class Personas {


        public int id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        
        public DateTime nacimiento { get; set; }
        public string nacimiento2 { get => nacimiento.ToString("dd/MM/yyyy"); }

        public string profile { get; set; }
        public string Description { get; set; }
    }
}