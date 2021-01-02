using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Get_Projekat.Services.Ispit
{
    public interface IIspitService
    {
        IEnumerable<Model.Ispit> GetIspitsByBrojIndeksa(string brojIndeksa);
    }
}
