using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadMangerForm.Model
{
    public class Trinkbrunnen // This class is used to represent the Trinkbrunnen table in the database
    {
        public int? TrinkbrunnenID { get; set; }
        public string? Name { get; set; }
        public bool? Funktionsfähig { get; set; }
        public int? Bewertung { get; set; }
        public string? Zustand { get; set; }
        public int? KoordinatenID { get; set; }

        public Koordinaten? Koordinaten { get; set; }
    }

}
