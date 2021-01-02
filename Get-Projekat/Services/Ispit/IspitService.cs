using Get_Projekat.Repositories.Ispit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Get_Projekat.Services.Ispit
{
    public class IspitService : IIspitService
    {
        private readonly IIspitReposutory _ispitReposutory;

        public IspitService(IIspitReposutory ispitReposutory)
        {
            _ispitReposutory = ispitReposutory;
        }

        public IEnumerable<Model.Ispit> GetIspitsByBrojIndeksa(string brojIndeksa)
        {
            return _ispitReposutory.GetIspitsByBrojIndeksa(brojIndeksa);
        }
    }
}
