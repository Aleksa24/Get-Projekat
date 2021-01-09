using Get_Projekat.Repositories.Ispit;
using Get_Projekat.Services.Ispit;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Get_Projekat.Test.Services.Ispit
{
    public class IspitServiceTest
    {
        private readonly IIspitService _ispitService;
        private readonly Mock<IIspitReposutory> _ispitRepository
            = new Mock<IIspitReposutory>();

        public IspitServiceTest()
        {
            _ispitService = new IspitService(_ispitRepository.Object);
        }

        [Fact]
        public void GetIspitsByBrojIndeksa()
        {
            // Arrange
            var brojIndeksa = "20150226";
            var lista = this.GetListOfIspits();
            _ispitRepository.Setup(x => x.GetIspitsByBrojIndeksa(brojIndeksa))
                .Returns(lista);
            //Act
            var listaIspita = _ispitService.GetIspitsByBrojIndeksa(brojIndeksa);
            //Assert
            Assert.Equal(listaIspita, lista);
        }

        private IEnumerable<Model.Ispit> GetListOfIspits()
        {
            var ispit = new Model.Ispit();
            ispit.BrojIndeksa = "20150226";
            ispit.PredmetId = 1;
            ispit.PredmetId = 10;

            var ispit2 = new Model.Ispit();
            ispit2.BrojIndeksa = "20150226";
            ispit2.PredmetId = 2;
            ispit2.PredmetId = 10;

            return new List<Model.Ispit>() { ispit, ispit2 };
        }
    }
}
