using Challenge.MELI.ApiClient.Exceptions;
using Challenge.MELI.ApiClient.Response;
using Challenge.MELI.ApiClient.Service.Interface;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.MELI.ApiClient.Service
{
    public class CountryService : ICountryService
    {
        private readonly ICountryServiceCliente _CountryServiceClient;

        private readonly string API_KEY = "64f0b762acccdfd50ee4026132bfe25a";
        public CountryService(ICountryServiceCliente countryServiceClient)
        {
            _CountryServiceClient = countryServiceClient;
        }
        public async Task<CountryResponse> GetCountryByNameAsync(string name)
        {
            try
            {
                var response = await _CountryServiceClient.GetCountryByNameAsync(name, API_KEY, true);

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
