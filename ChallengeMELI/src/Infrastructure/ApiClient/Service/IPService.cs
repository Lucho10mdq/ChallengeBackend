using Challenge.MELI.ApiClient.Exceptions;
using Challenge.MELI.ApiClient.Response;
using Challenge.MELI.ApiClient.Service.Interface;
using System;
using System.Threading.Tasks;

namespace Challenge.MELI.ApiClient.Service
{
    public class IPService : IIPService
    {
        private readonly IIPServiceClient _IPCountryServiceClient;

        private readonly string API_KEY = "9572b5ad29aa7c5993ac4f0d98d4b3c1";
        public IPService(IIPServiceClient iPCountryServiceClient)      
        {
            _IPCountryServiceClient = iPCountryServiceClient;
        }
        public async Task<IpResponse> GetIpByIpAsync(string ip)
        {
            try
            {
                var response = await _IPCountryServiceClient.GetIpCountryByIpAsync(ip, API_KEY,"1");

                if (response.IsSuccessStatusCode) 
                {
                    return response.Content;
                }
                else 
                {
                    throw new GenericExceptionClient(response.Error.ToString(), "", response.StatusCode);
                }           
            }
            catch(Exception ex) 
            {
                throw ex;
            } 
        }
    }
}
