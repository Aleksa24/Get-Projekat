using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Get_Projekat.Services.Student
{
    public interface IStudentService
    {
        IEnumerable<Model.Student> GetAll();
        Model.Student New(Model.Student studentToBeCreated);
        Model.Student Update(Model.Student studentToBeUpdated);
        void DeleteByBrojIndeksa(string brojIndeksa);
        Model.Student GetByBrojIndeksa(string brojIndeksa);
    }
}
