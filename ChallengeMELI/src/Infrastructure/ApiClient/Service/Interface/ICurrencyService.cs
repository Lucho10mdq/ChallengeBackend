using Challenge.MELI.ApiClient.Response;
using System.Threading.Tasks;

namespace Challenge.MELI.ApiClient.Service.Interface
{
    public interface ICurrencyService
    {
        Task<CurrencyResponse> GetCurrencyByCodeAsync(string code);
    }
}
