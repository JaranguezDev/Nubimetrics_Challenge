using Nubimetrics_Challenge.Services.Country.Dtos;
using System.Threading.Tasks;

namespace Nubimetrics_Challenge.Services.Country.Interfaces
{
    public interface ICountryService
    {
        public Task<CountryDto> GetCountryByCode(string name);
    }
}
