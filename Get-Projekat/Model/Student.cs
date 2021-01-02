using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Get_Projekat.Model
{
    public class Student
    {
        [Key]
        public string BrojIndeksa { get; set; }
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }
        [Required]
        public string Adresa { get; set; }
        [Required]
        public string Grad { get; set; }
        public ICollection<Ispit> ListaIspita { get; set; }

        public override string ToString()
        {
            if (BrojIndeksa == null) { BrojIndeksa = "n/a"; }
            return BrojIndeksa+" "+Ime+""+Prezime+" "+Grad+" "+Adresa;
        }
    }

}
