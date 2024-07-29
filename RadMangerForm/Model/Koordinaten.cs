using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadMangerForm.Model
{
    public class Koordinaten // This class is used to represent the Koordinaten table in the database
    {
        public int KoordinatenID { get; set; }
        public decimal? Breitengrad { get; set; }
        public decimal? Längengrad { get; set; }
    }
}
