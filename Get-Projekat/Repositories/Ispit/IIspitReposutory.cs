using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Get_Projekat.Repositories.Ispit
{
    public interface IIspitReposutory
    {
        IEnumerable<Model.Ispit> GetIspitsByBrojIndeksa(string brojIndeksa);
    }
}
