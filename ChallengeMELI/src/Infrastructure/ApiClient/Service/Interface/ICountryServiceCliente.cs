using Challenge.MELI.ApiClient.Response;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Challenge.MELI.ApiClient.Service.Interface
{
    public interface ICountryServiceCliente
    {
        [Get("/v2/name/{name}")]
        Task<ApiResponse<List<CountryResponse>>> GetCountryByNameAsync(string name, [Query] string access_key, [Query] bool fullText);
    }
}
