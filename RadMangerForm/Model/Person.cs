using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadMangerForm.Model
{
    public class Person // This class is used to represent the Person table in the database
    {
        public int PersonID { get; set; }
        public string? Vorname { get; set; }
        public string? Nachname { get; set; }
        public DateTime GebDatum { get; set; }
        public int FahrradID { get; set; }
        public string? Adresse { get; set; }
        public string? EMail { get; set; }
    }
}
