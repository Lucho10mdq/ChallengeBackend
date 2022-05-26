using Challenge.MELI.ApiClient.Exceptions;
using Challenge.MELI.ApiClient.Response;
using Challenge.MELI.ApiClient.Service.Interface;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.MELI.ApiClient.Service
{
    public class CurrencyService : ICurrencyService
    {
        private readonly ICurrencyServiceClient _currencyServiceClient;

        public CurrencyService(ICurrencyServiceClient currencyServiceClient)
        {
            _currencyServiceClient = currencyServiceClient;
        }

        public async Task<CurrencyResponse> GetCurrencyByCodeAsync(string code)
        {
            try
            {
                var response = await _currencyServiceClient.GetCurrencyByCodeAsync(code);

                if (response.IsSuccessStatusCode)
                {
                    return response.Content.FirstOrDefault();
                }
                else
                {
                    throw new GenericException(response.Error.ToString(), response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
