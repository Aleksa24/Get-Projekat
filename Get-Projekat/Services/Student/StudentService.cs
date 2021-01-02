using Get_Projekat.Exceptions.Student;
using Get_Projekat.Repositories.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Get_Projekat.Services.Student
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;

        public StudentService(IStudentRepository studentRepository)
        {
            _repository = studentRepository;
        }
        public void DeleteByBrojIndeksa(string brojIndeksa)
        {
            var studentToDelete = _repository.GetByBrojIndeksa(brojIndeksa);

            if (studentToDelete == null)
            {
                throw new StudentNotFoundException("Studnet sa indeksom " + brojIndeksa + " nije pronadjen!");
            }

            studentToDelete.ListaIspita.ToList().ForEach(ispit => _repository.DeleteIspit(ispit));
            _repository.Delete(studentToDelete);
            _repository.SaveChanges();
        }

        public IEnumerable<Model.Student> GetAll()
        {
            return _repository.GetAll();
        }

        public Model.Student GetByBrojIndeksa(string brojIndeksa)
        {
            return _repository.GetByBrojIndeksa(brojIndeksa);
        }

        public Model.Student New(Model.Student student)
        {
            var doesStudentwithBIExists = _repository.GetByBrojIndeksa(student.BrojIndeksa);

            if (doesStudentwithBIExists != null)
            {
                throw new StudentAlreadyExistsException(@"Student with {student.BrojIndexa} vec postoji");
            }

            _repository.Save(student);

            _repository.SaveChanges();

            return student;
        }

        public Model.Student Update(Model.Student student)
        {
            var studentInDb = _repository.GetByBrojIndeksa(student.BrojIndeksa);

            if (studentInDb == null)
            {
                throw new StudentNotFoundException("Studnet sa indeksom " + student.BrojIndeksa + " nije pronadjen!");
            }

            MapToEntityStudent(studentInDb,student);
            
            _repository.Update(studentInDb);

            _repository.SaveChanges();

            return student;
        }

        private void MapToEntityStudent(Model.Student studentInDb, Model.Student student)
        {
            studentInDb.Grad = student.Grad;
            studentInDb.Ime = student.Ime;
            studentInDb.Prezime = student.Prezime;
            studentInDb.Adresa = student.Adresa;

            studentInDb.ListaIspita.ToList().ForEach(ispit => _repository.DeleteIspit(ispit));
            studentInDb.ListaIspita = student.ListaIspita;
        }
    }
}
