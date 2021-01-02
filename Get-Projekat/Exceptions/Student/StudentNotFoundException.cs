using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Get_Projekat.Exceptions.Student
{
    public class StudentNotFoundException : Exception
    {
        public StudentNotFoundException(string message) : base(message)
        {
        }
    }
}
