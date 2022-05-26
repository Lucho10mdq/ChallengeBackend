using Challenge.MELI.ApiClient.Service.Interface;
using Challenge.MELI.Application.Exceptions;
using Challenge.MELI.Domain;
using Challenge.MELI.Domain.Interface.Repository.Command;
using Challenge.MELI.Domain.Interface.Repository.Query;
using Challenge.MELI.Domain.Interface.Service;
using Challenge.MELI.Helpers;
using System.Threading.Tasks;

namespace Challenge.MELI.Application.Service
{
    public class FraudService : IFraudService
    {
        private readonly IIPService _IPService;
        private readonly ICountryService _CountryService;
        private readonly ICurrencyService _CurrencyService;
        private readonly IIFraudeRepository _fraudeRepository;
        private readonly IStatsService _statsService;
        private readonly IFraudeQuery _fraudeQuery;
        public FraudService(IIPService  IPCountryService,
                            IIFraudeRepository fraudeRepository, 
                            ICountryService countryService, 
                            ICurrencyService currencyService,
                            IStatsService statsService,
                            IFraudeQuery fraudeQuery) 
        {
            _IPService = IPCountryService;
            _fraudeRepository = fraudeRepository;
            _CountryService = countryService;
            _CurrencyService = currencyService;
            _statsService = statsService;
            _fraudeQuery = fraudeQuery;
        }
        public async Task<InformationFraudDto> GetInformationFraudeAsync(string ip)
        {
            
            var informationFraudeDto = await _fraudeQuery.GetInformationFraudeAsync(ip);

            informationFraudeDto = await BuildInformationFraudeAsync(ip, informationFraudeDto);

            return informationFraudeDto;
        }

        private async Task<InformationFraudDto> BuildInformationFraudeAsync(string ip, InformationFraudDto informationFraudeDto)
        {
            
            if (informationFraudeDto == null)
            {
                informationFraudeDto = new InformationFraudDto();

                var ipCountryResponse = await _IPService.GetIpByIpAsync(ip);

                ValidateIpResponseCallBack(ipCountryResponse);

                var countryReponse = await _CountryService.GetCountryByNameAsync(ipCountryResponse.Country_Name);

                var currencyResponse = await _CurrencyService.GetCurrencyByCodeAsync(countryReponse.Alpha3Code);               

                informationFraudeDto.BuildInformationFraudDto(ipCountryResponse, countryReponse,currencyResponse);
                
                await _fraudeRepository.AddFraudeAsync(informationFraudeDto);
                
            }

            await _statsService.AddStatsAsync(informationFraudeDto);

            return informationFraudeDto;
        }

        private static void ValidateIpResponseCallBack(ApiClient.Response.IpResponse ipCountryResponse)
        {
            if (string.IsNullOrEmpty(ipCountryResponse.Country_Name))
            {
                throw new GenericException(MessageGeneral.NotFound, MessageGeneral.DontExist);
            }
        }
    }
}
