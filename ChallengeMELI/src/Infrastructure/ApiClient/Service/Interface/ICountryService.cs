using Challenge.MELI.ApiClient.Response;
using System.Threading.Tasks;

namespace Challenge.MELI.ApiClient.Service.Interface
{
    public interface ICountryService
    {
        Task<CountryResponse> GetCountryByNameAsync(string name);
    }
}
