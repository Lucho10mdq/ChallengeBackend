using Challenge.MELI.ApiClient.Service.Interface;
using Challenge.MELI.Application.Exceptions;
using Challenge.MELI.Domain;
using Challenge.MELI.Domain.Interface.Service;
using Challenge.MELI.Helpers;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using System.Threading.Tasks;

namespace Challenge.MELI.Application.Service
{
    public class FraudeService : IFraudeService
    {
        private readonly IIPService _IPService;
        private readonly ICountryService _CountryService;
        private readonly IDistributedCache _distributedCache;
        public FraudeService(IIPService  IPCountryService, IDistributedCache distributedCache, ICountryService countryService) 
        {
            _IPService = IPCountryService;
            _distributedCache = distributedCache;
            _CountryService = countryService;
        }
        public async Task<InformationFraudDto> GetInformationFraudeAsync(string ip)
        {
            var informationFraude = await _distributedCache.GetAsync(ip);

            var informationFraudeDto = await BuildInformationFraudeAsync(ip, informationFraude);

            return informationFraudeDto;
        }

        private async Task<InformationFraudDto> BuildInformationFraudeAsync(string ip, byte[] informationFraude)
        {
            var informationFraudeDto = new InformationFraudDto();
            
            if (informationFraude != null)
            {
                await _distributedCache.RemoveAsync(ip);// borrar linea, solo test
                informationFraudeDto = FromByteCache(informationFraude);

                return informationFraudeDto;
            }
            else
            {
                var ipCountryResponse = await _IPService.GetIpByIpAsync(ip);

                ValidateIpResponseCallBack(ipCountryResponse);

                var countryReponse = await _CountryService.GetCountryByNameAsync(ipCountryResponse.Country_Name);

                await _distributedCache.SetAsync(ip, ToByteCache(informationFraudeDto));

                informationFraudeDto.BuildInformationFraudDto(ipCountryResponse, countryReponse);

                return informationFraudeDto;
            }
        }

        private static void ValidateIpResponseCallBack(ApiClient.Response.IpResponse ipCountryResponse)
        {
            if (string.IsNullOrEmpty(ipCountryResponse.Country_Name))
            {
                throw new GenericException(MessageGeneral.NotFound, MessageGeneral.DontExist);
            }
        }

        private byte[] ToByteCache(InformationFraudDto informationFraudeDto)
        {
            return JsonSerializer.SerializeToUtf8Bytes(informationFraudeDto);
        }

        private InformationFraudDto FromByteCache(byte[] data)
        {
            return JsonSerializer.Deserialize<InformationFraudDto>(data);
        }
    }
}
