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

        private readonly string API_KEY = "da0d991f10665cf1fca4665d07b5f3c1";
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
                    throw new GenericExceptionClient(response.Error.ToString(),"", response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
