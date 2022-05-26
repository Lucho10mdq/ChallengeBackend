using Challenge.MELI.ApiClient.Response;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Challenge.MELI.ApiClient.Service.Interface
{
    public interface ICurrencyServiceClient
    {
        [Get("/v3.1/alpha/{code}")]
        Task<ApiResponse<List<CurrencyResponse>>> GetCurrencyByCodeAsync(string code);
    }
}
