using Moq;
using Nubimetrics_Challenge.Services.Country.Interfaces;
using Nubimetrics_Challenge.WebApi.Controllers;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Nubimetrics_Challenge.UnitTests
{
    public class CountryEndpoint_Should
    {
        [Fact]
        public async Task CountryEndpoint_ReturnUnauthorizeFor_CO()
        {
            // Arrange
            const string COUNTRY_CODE = "CO";
            var mockCountryService = new Mock<ICountryService>();
            var countryController = new CountryController(mockCountryService.Object);

            // Act
            var result = await countryController.GetCountryByCode(COUNTRY_CODE);

            // Assert

        }
    }
}
