using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadMangerForm.Model
{
    public class Fahrrad // This class is used to represent the Fahrrad table in the database
       {
        public int FahrradID { get; set; }
        public string? Fahrradname { get; set; }
        public string? Hersteller { get; set; }
        public int Modelljahr { get; set; }
        public decimal Preis { get; set; }
    }
}
