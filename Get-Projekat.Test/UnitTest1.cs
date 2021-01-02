using System;
using Xunit;
using Get_Projekat.Controllers;
using Get_Projekat.Model;

namespace Get_Projekat.Test
{
    public class UnitTest1
    {
        private readonly StudentController _studentController;

        //public UnitTest1(StudentController studentController)
        //{
        //    _studentController = studentController;
       // }

        [Fact]
        public void GetAllStudentsTest()
        {
           // var students = _studentController.GetAllStudents();
            //Console.WriteLine(students.Value);
            Assert.Equal("str","strr");
        }
    }
}
