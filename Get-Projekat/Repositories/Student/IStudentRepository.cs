using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Get_Projekat.Repositories.Student
{
    public interface IStudentRepository
    {
        IEnumerable<Model.Student> GetAll();
        Model.Student GetByBrojIndeksa(string brojIndeksa);
        void Save(Model.Student studentToBeCreated);
        void SaveChanges();
        void Update(Model.Student studentToBeUpdated);
        void Delete(Model.Student student);
        void DeleteIspit(Model.Ispit ispit);
    }
}
