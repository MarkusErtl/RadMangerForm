using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadMangerForm.Model
{
    public class Bundesland // This class is used to represent the Bundesland table in the database
    {
        public int BundeslandID { get; set; }
        public string? Name { get; set; }
        public int PersonenID { get; set; }
        public int StreckenID { get; set; }
        public string? Hauptstadt { get; set; }
        public int Einwohnerzahl { get; set; }
        public int Fläche { get; set; }
    }
}
