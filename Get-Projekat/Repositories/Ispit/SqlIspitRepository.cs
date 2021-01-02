using Get_Projekat.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Get_Projekat.Repositories.Ispit
{
    public class SqlIspitRepository : IIspitReposutory
    {
        private readonly DataContext _context;

        public SqlIspitRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Model.Ispit> GetIspitsByBrojIndeksa(string brojIndeksa)
        {
            return _context.Ispiti.ToList().Where(ispit => ispit.BrojIndeksa == brojIndeksa);
        }
    }
}
