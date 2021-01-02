using Get_Projekat.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Get_Projekat.Controllers
{
    [ApiController]
    public class ErrorController : Controller
    {
        [Route("/error")]
       // [EnableCors("Development")]
        public IActionResult HandleErrors()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var statusCode = exception.Error.GetType().Name switch
            {
                "StudentNotFoundException" => HttpStatusCode.NotFound,
                "StudentAlreadyExistsException" => HttpStatusCode.PreconditionFailed,
                _ => HttpStatusCode.InternalServerError
            };

            return Problem(detail: exception.Error.Message,statusCode:(int) statusCode);
        }
    }
}
