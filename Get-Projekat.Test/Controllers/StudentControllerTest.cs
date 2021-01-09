using Microsoft.AspNetCore.Mvc.Testing;
using RESTFulSense.Clients;
using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Get_Projekat.Test.Controllers
{
    class StudentControllerTest
    {
        private readonly WebApplicationFactory<Startup> webApplicationFactory;
        private readonly HttpClient baseClient;
        private readonly IRESTFulApiFactoryClient apiFactoryClient;

        public StudentControllerTest()
        {
            this.webApplicationFactory = new WebApplicationFactory<Startup>();
            this.baseClient = this.webApplicationFactory.CreateClient();
            this.apiFactoryClient = new RESTFulApiFactoryClient(this.baseClient);   
        }
    }
}
