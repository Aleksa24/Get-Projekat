using System;
using Xunit;
using Get_Projekat.Controllers;
using Get_Projekat.Model;
using Get_Projekat.Services.Student;
using Moq;
using Get_Projekat.Repositories.Student;
using System.Collections.Generic;
using Get_Projekat.Exceptions.Student;

namespace Get_Projekat.Test
{
    public class StudentServiceTest
    {
        private readonly IStudentService _studentService;
        private readonly Mock<IStudentRepository> _studentRepository =
            new Mock<IStudentRepository>();

        public StudentServiceTest()
        {
            _studentService = new StudentService(_studentRepository.Object);
        }

        [Fact]
        public void DeleteByBrojIndeksa()
        {
            //Arrange
            var brojIndeksa = "20150226";
            var studentToBeDeleted = this.GetStudentToBeCreated();
            _studentRepository.Setup(x => x.GetByBrojIndeksa(brojIndeksa))
                .Returns(studentToBeDeleted);
            _studentRepository.Setup(x => x.DeleteIspit(It.IsAny<Ispit>()))
                .Callback((Ispit ispit) => studentToBeDeleted.ListaIspita.Remove(ispit));
            _studentRepository.Setup(x => x.Delete(studentToBeDeleted));
            _studentRepository.Setup(x => x.SaveChanges());
            //Act
            _studentService.DeleteByBrojIndeksa(brojIndeksa);
            //Assert
            
        }

        [Fact]
        public void GetAll_ReturnsValid()
        {
            //Arrange
            var listOfStudents = this.GetDefaultListOfStudents();
            _studentRepository.Setup(x => x.GetAll())
                .Returns(listOfStudents);
            //Act
            var returnedListOfStudents = _studentService.GetAll();
            //Assert
            Assert.Equal(listOfStudents, returnedListOfStudents);
        }

        [Fact]
        public void GetByBrojIndeksa_ReturnsValidStudent()
        {
            //Arrange
            var studentId = "20150226";
            _studentRepository.Setup(x => x.GetByBrojIndeksa(studentId))
                .Returns(this.GetStudentDefaultStudentForTesting());
            //Act
            var student = _studentService.GetByBrojIndeksa(studentId);
            //Assert
            Assert.Equal(studentId,student.BrojIndeksa);
        }

        [Fact]
        public void New_ReturnsSavedStudent_WhenStudentWithBrojIndeksaDoesntExist()
        {
            //Arrange
            var studentToBeCreated = this.GetStudentToBeCreated();
            _studentRepository.Setup(x => x.GetByBrojIndeksa(studentToBeCreated.BrojIndeksa))
                .Returns(() => null);
            _studentRepository.Setup(x => x.Save(studentToBeCreated));
            _studentRepository.Setup(x => x.SaveChanges());
            //Act
            var student = _studentService.New(studentToBeCreated);
            //Assert
            Assert.Equal(studentToBeCreated, student);
        }

        [Fact]
        public void New_ThrowsStudentAlreadyExistsException_WhenStudentExists()
        {
            //Arrange
            bool isExceptionThrown = false;
            var studentToBeCreated = this.GetStudentToBeCreated();
            _studentRepository.Setup(x => x.GetByBrojIndeksa(studentToBeCreated.BrojIndeksa))
                .Returns(() => studentToBeCreated);
            _studentRepository.Setup(x => x.Save(studentToBeCreated));
            _studentRepository.Setup(x => x.SaveChanges());
            //Act
            try
            {
                var student = _studentService.New(studentToBeCreated);
            }
            catch (StudentAlreadyExistsException e)
            {
                //dobro ponasanje
                isExceptionThrown = true;
            }
            //Assert
            Assert.Equal(isExceptionThrown,true);
        }

        [Fact]
        public void Update_ReturnsUpdatedStudent_WhenStudentWithBrojIndeksaExist()
        {
            //Arrange
            var studentToBeUpdated = this.GetStudentToBeCreated();
            _studentRepository.Setup(x => x.GetByBrojIndeksa(studentToBeUpdated.BrojIndeksa))
                .Returns(studentToBeUpdated);
            _studentRepository.Setup(x => x.Update(studentToBeUpdated));
            _studentRepository.Setup(x => x.SaveChanges());
            //Act
            var student = _studentService.Update(studentToBeUpdated);
            //Assert
            Assert.Equal(studentToBeUpdated, student);
        }

        [Fact]
        public void Update_ThrowsStudentNotFoundException_WhenStudentDoesntExists()
        {
            //Arrange
            bool isExceptionThrown = false;
            var studentToBeUpdated = this.GetStudentToBeCreated();
            _studentRepository.Setup(x => x.GetByBrojIndeksa(studentToBeUpdated.BrojIndeksa))
                .Returns(() => null);
            _studentRepository.Setup(x => x.Update(studentToBeUpdated));
            _studentRepository.Setup(x => x.SaveChanges());
            //Act
            try
            {
                var student = _studentService.Update(studentToBeUpdated);
            }
            catch (StudentNotFoundException e)
            {
                //dobro ponasanje
                isExceptionThrown = true;
            }
            //Assert
            Assert.Equal(isExceptionThrown, true);
        }


        private Student GetStudentDefaultStudentForTesting()
        {
            var student = new Student();
            student.BrojIndeksa = "20150226";

            return student;
        }
        private Student GetStudentToBeCreated()
        {
            var ispit = new Ispit();
            ispit.BrojIndeksa = "20150226";
            ispit.PredmetId = 1;
            ispit.PredmetId = 10;

            var student = new Student();
            student.BrojIndeksa = "20150226";
            student.Adresa = "Jurija Gagarina";
            student.Grad = "Beograd";
            student.Ime = "Aleksa";
            student.Prezime = "Ivanovic";
            student.ListaIspita = new List<Ispit>() { ispit };

            return student;
        }
        private List<Student> GetDefaultListOfStudents()
        {
            return new List<Student>() { new Student(), new Student(), new Student() };
        }
        
    }
    
}
