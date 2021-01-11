using Get_Projekat.Model;
using Get_Projekat.Services.Ispit;
using Get_Projekat.Services.Student;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Get_Projekat.Controllers
{
    [Route("student")]
    [ApiController]
    //[EnableCors("_myAllowSpecificOrigins")]
    [EnableCors("policy")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IIspitService _ispitService;

        public StudentController(IIspitService ispitService, IStudentService studentService)
        {
            _ispitService = ispitService;
            _studentService = studentService;
        }

        [HttpGet]
        public ActionResult <IEnumerable<Student>> GetAllStudents()
        {
            return Ok(_studentService.GetAll());
        }
        
        [HttpGet("{brojIndeksa}",Name = "GetStudentByBrojIndeksa")]
        public ActionResult<Student> GetStudentByBrojIndeksa(string brojIndeksa)
        {
            return Ok(_studentService.GetByBrojIndeksa(brojIndeksa));
        }
       
        [HttpPost]
        [EnableCors("policy")]
        public ActionResult <Student> CreateStudent(Student studentToBeCreated)
        {
            var savedStudent = _studentService.New(studentToBeCreated);

            return CreatedAtRoute(nameof(GetStudentByBrojIndeksa), new { brojIndeksa = savedStudent.BrojIndeksa},savedStudent);
        }
        
        [HttpPut]
        public ActionResult <Student> UpdateStudent(Student studentToBeUpdated)
        {
            return Ok(_studentService.Update(studentToBeUpdated));
        }
        
        [HttpDelete("{brojIndeksa}")]
        public ActionResult DeleteByBrojIndeksa(string brojIndeksa)
        {
            _studentService.DeleteByBrojIndeksa(brojIndeksa);
            return NoContent();
        }
    }
}
