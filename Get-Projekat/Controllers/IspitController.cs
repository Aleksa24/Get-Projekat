using Get_Projekat.Model;
using Get_Projekat.Services.Ispit;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Get_Projekat.Controllers
{
    [ApiController]
    [Route("ispit")]
    [EnableCors("policy")]
    public class IspitController: ControllerBase
    {
        private readonly IIspitService _ispitService;

        public IspitController(IIspitService ispitService)
        {
            _ispitService = ispitService;
        }

        [Route("broj-indeksa/{brojIndeksa}")]
        public ActionResult<IEnumerable<Ispit>> GetIspitsByBrojIndeksa(string brojIndeksa)
        {
            return Ok(_ispitService.GetIspitsByBrojIndeksa(brojIndeksa));
        }
    }
}
