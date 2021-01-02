using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Get_Projekat.Exceptions.Student
{
    public class StudentAlreadyExistsException : Exception
    {
        public StudentAlreadyExistsException(string message) : base(message)
        {
        }
    }
}
