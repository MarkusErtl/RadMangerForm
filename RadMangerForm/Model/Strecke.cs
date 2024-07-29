using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadMangerForm.Model
{
    public class Strecke // This class is used to represent the Strecke table in the database
    {
        public int? StreckenID { get; set; }
        public string? Name { get; set; }
        public int Länge { get; set; }
        public TimeSpan Dauer { get; set; }
        public int Schwierigkeitsgrad { get; set; }
        public int? BundeslandID { get; set; }
        public int? TrinkbrunnenID { get; set; }
        public int? BelagID { get; set; }

        public Belag? Belag { get; set; }
        public Trinkbrunnen? Trinkbrunnen { get; set; }
       

        public override string ToString()
        {
            return $"{Name}\t({Länge} km)\t{Schwierigkeitsgrad} ";
        }


    }
}
