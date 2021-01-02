using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Get_Projekat.Model
{
    public class Ispit
    {
        [ForeignKey("Student")]
        public string BrojIndeksa { get; set; }
        public Int64 PredmetId { get; set; }
        public Int16 Ocena { get; set; }
    }
}
