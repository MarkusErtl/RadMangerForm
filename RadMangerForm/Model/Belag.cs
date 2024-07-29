using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadMangerForm.Model
{
    public class Belag // This class is used to represent the Belag table in the database
    {
        public int? BelagID { get; set; }
        public string? Name { get; set; }
        public string? Zustand { get; set; }
    }
}
