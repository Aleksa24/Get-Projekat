using Microsoft.AspNetCore.Mvc.Testing;
using RESTFulSense.Clients;
using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Get_Projekat.Controllers;
using Moq;
using Get_Projekat.Services.Student;
using Get_Projekat.Services.Ispit;
using Xunit;
using Get_Projekat.Model;
using Microsoft.AspNetCore.Mvc;

namespace Get_Projekat.Test.Controllers
{
    public class StudentControllerTest
    {
        private readonly StudentController _studentControlller;
        private readonly Mock<IStudentService> _studentService = new Mock<IStudentService>();
        private readonly Mock<IIspitService> _ispitService = new Mock<IIspitService>();

        public StudentControllerTest()
        {
            _studentControlller = new StudentController(_ispitService.Object,_studentService.Object);
        }

        [Fact]
        public void GetAllStudents_ReturnsValidResault()
        {
            //Arrange
            var listOfStudents = this.GetListOfStudents();
            _studentService.Setup(x => x.GetAll())
                .Returns(listOfStudents);
            //Act
            ActionResult<IEnumerable<Student>> result = _studentControlller.GetAllStudents();
            //Assert
            Assert.IsType<ActionResult<IEnumerable<Student>>>(result);

            Assert.Equal(((OkObjectResult)result.Result).Value, listOfStudents);
        }
        
        [Fact]
        public void GetStudentByBrojIndeksa_ReturnsValidResult()
        {
            //Arrange
            string brojIndeksa = "20150226";
            var student = this.GetDefaultStudent();
            _studentService.Setup(x => x.GetByBrojIndeksa(brojIndeksa))
                .Returns(student);
            //Act
            ActionResult<Student> result = _studentControlller.GetStudentByBrojIndeksa(brojIndeksa);
            //Assert
            Assert.IsType<ActionResult<Student>>(result);

            Assert.Equal(((OkObjectResult)result.Result).Value, student);
        }

        [Fact]
        public void CreateStudent_ReturnsCreatedStudent()
        {
            //Arrange
            var studentToBeCreated = this.GetDefaultStudent();
            _studentService.Setup(x => x.New(studentToBeCreated))
                .Returns(studentToBeCreated);
            //Act
            ActionResult<Student> result = _studentControlller.CreateStudent(studentToBeCreated);
            //Assert
            Assert.IsType<ActionResult<Student>>(result);

            Assert.Equal(((CreatedAtRouteResult)result.Result).Value, studentToBeCreated);
        }

        [Fact]
        public void UpdateStudent_ReturnsCreatedStudent()
        {
            //Arrange
            var studentToBeUpdated = this.GetDefaultStudent();
            _studentService.Setup(x => x.Update(studentToBeUpdated))
                .Returns(studentToBeUpdated);
            //Act
            ActionResult<Student> result = _studentControlller.UpdateStudent(studentToBeUpdated);
            //Assert
            Assert.IsType<ActionResult<Student>>(result);

            Assert.Equal(((OkObjectResult)result.Result).Value, studentToBeUpdated);
        }

        [Fact]
        public void DeleteByBrojIndeksa_ReturnsNoContent()
        {
            //Arrange
            var brojIndeksa = "20150226";
            _studentService.Setup(x => x.DeleteByBrojIndeksa(brojIndeksa));
            //Act
            ActionResult result = _studentControlller.DeleteByBrojIndeksa(brojIndeksa);
            //Assert
            Assert.IsType<NoContentResult>(result);
        }


        private Student GetDefaultStudent()
        {
            var ispit1 = new Ispit() 
            { 
                BrojIndeksa = "20150226",
                PredmetId = 1,
                Ocena = 10 
            };
            var ispit2 = new Ispit()
            {
                BrojIndeksa = "20150226",
                PredmetId = 2,
                Ocena = 9
            };

            return new Student()
            {
                BrojIndeksa = "20150226",
                Ime = "Aleksa",
                Prezime = "Ivanovic",
                Grad = "Beograd",
                Adresa = "Jurija Gagarina",
                ListaIspita = new List<Ispit>() { ispit1,ispit2}
            };
        }

        private List<Student> GetListOfStudents()
        {
            var student1 = new Student()
            {
                BrojIndeksa = "20150226",
                Ime = "Aleksa",
                Prezime = "Ivanovic",
                Grad = "Beograd",
                Adresa = "Jurija Gagarina",
                ListaIspita = new List<Ispit>()
            };
            var student2 = new Student()
            {
                BrojIndeksa = "20150227",
                Ime = "Aleksaa",
                Prezime = "Ivanovicc",
                Grad = "Beogradd",
                Adresa = "Jurija Gagarinaa",
                ListaIspita = new List<Ispit>()
            };

            return new List<Student>() { student1, student2 };
        }
    }
}
