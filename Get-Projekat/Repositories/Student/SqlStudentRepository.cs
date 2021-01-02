using Get_Projekat.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Get_Projekat.Repositories.Student
{
    public class SqlStudentRepository : IStudentRepository
    {
        private readonly DataContext _context;

        public SqlStudentRepository(DataContext context)
        {
            _context = context;
        }

        public void Delete(Model.Student studentToDelete)
        {
            _context.Studenti.Remove(studentToDelete);
        }

        public void DeleteIspit(Model.Ispit ispit)
        {
            
            _context.Ispiti.Remove(ispit);
        }

        public IEnumerable<Model.Student> GetAll()
        {
            return _context.Studenti.ToList();
        }

        public Model.Student GetByBrojIndeksa(string brojIndeksa)
        {
            return _context.Studenti.Include("ListaIspita").FirstOrDefault(student => student.BrojIndeksa == brojIndeksa);
        }

        public void Save(Model.Student studentToBeCreated)
        {
            _context.Studenti.Add(studentToBeCreated);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Model.Student studentToBeUpdated)
        {
            //does nothing
        }
    }
}
