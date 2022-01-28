using Nubimetrics_Challenge.Services.Search.Dtos;
using System.Threading.Tasks;

namespace Nubimetrics_Challenge.Services.Search.Interfaces
{
    public interface ISearchService
    {
        public Task<SearchDto> FindProductsByCriteria(string criteria);
    }
}
