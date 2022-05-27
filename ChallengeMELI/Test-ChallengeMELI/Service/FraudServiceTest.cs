using Challenge.MELI.ApiClient.Response;
using Challenge.MELI.ApiClient.Service.Interface;
using Challenge.MELI.Application.Exceptions;
using Challenge.MELI.Application.Service;
using Challenge.MELI.Domain;
using Challenge.MELI.Domain.Interface.Repository.Command;
using Challenge.MELI.Domain.Interface.Repository.Query;
using Challenge.MELI.Domain.Interface.Service;
using Challenge.MELI.Helpers;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Test_ChallengeMELI.Service
{
    [Trait("FraudServiceTest", "Fraud service")]
    public class FraudServiceTest
    {
        private readonly Mock<IIPService> _IPService;
        private readonly Mock<ICountryService> _CountryService;
        private readonly Mock<ICurrencyService> _CurrencyService;
        private readonly Mock<IIFraudeRepository> _fraudeRepository;
        private readonly Mock<IStatsService> _statsService;
        private readonly Mock<IFraudeQuery> _fraudeQuery;
        private readonly string IP = "201.178.248.18";

        private readonly FraudService _fraudeService;
        public FraudServiceTest()
        {
            _IPService = new Mock<IIPService>();
            _CountryService = new Mock<ICountryService>();
            _CurrencyService = new Mock<ICurrencyService>();
            _fraudeRepository = new Mock<IIFraudeRepository>();
            _statsService = new Mock<IStatsService>();
            _fraudeQuery = new Mock<IFraudeQuery>();

            _fraudeService = new FraudService(_IPService.Object, _fraudeRepository.Object,
                                            _CountryService.Object, _CurrencyService.Object,
                                            _statsService.Object, _fraudeQuery.Object);
        }

        [Fact(DisplayName = "GET_INFORMATION_WHEN_IS_NOT_IN_CACHE")]
        public async Task GET_INFORMATION_WHEN_IS_NOT_IN_CACHE()
        {
            InformationFraudDto informationFraudDto = null;

            IpResponse ipResponse;
            CountryResponse countryResponse;
            CurrencyResponse currencyResponse;
            BuildInformation(out ipResponse, out countryResponse, out currencyResponse);

            _fraudeQuery.Setup(x => x.GetInformationFraudeAsync(It.IsAny<string>()))
                        .ReturnsAsync(informationFraudDto);

            _IPService.Setup(x => x.GetIpByIpAsync(It.IsAny<string>()))
                       .ReturnsAsync(ipResponse)
                       .Verifiable();

            _CountryService.Setup(x => x.GetCountryByNameAsync(It.IsAny<string>()))
                       .ReturnsAsync(countryResponse)
                       .Verifiable();

            _CurrencyService.Setup(x => x.GetCurrencyByCodeAsync(It.IsAny<string>()))
                       .ReturnsAsync(currencyResponse)
                       .Verifiable();

            _CurrencyService.Setup(x => x.GetCurrencyByCodeAsync(It.IsAny<string>()))
                       .ReturnsAsync(currencyResponse)
                       .Verifiable();

            _fraudeRepository.Setup(x => x.AddFraudeAsync(It.IsAny<InformationFraudDto>()))
                             .Verifiable();

            informationFraudDto = new InformationFraudDto();
            informationFraudDto.BuildInformationFraudDto(ipResponse, countryResponse, currencyResponse);

            var response = await _fraudeService.GetInformationFraudeAsync(IP);

            Assert.NotNull(response);

            _fraudeQuery.Verify(
              mock => mock.GetInformationFraudeAsync(It.IsAny<string>()),
              Times.Once);

            _IPService.Verify(
             mock => mock.GetIpByIpAsync(It.IsAny<string>()),
             Times.Once);

            _CountryService.Verify(
             mock => mock.GetCountryByNameAsync(It.IsAny<string>()),
             Times.Once);
            _fraudeRepository.Verify(
            mock => mock.AddFraudeAsync(It.IsAny<InformationFraudDto>()),
            Times.Once);
        }

        [Fact(DisplayName = "GET_INFORMATION_WHEN_IS_IN_CACHE")]
        public async Task GET_INFORMATION_WHEN_IS_IN_CACHE()
        {
            IpResponse ipResponse;
            CountryResponse countryResponse;
            CurrencyResponse currencyResponse;
            BuildInformation(out ipResponse, out countryResponse, out currencyResponse);

            InformationFraudDto informationFraudDto = null;
            informationFraudDto = new InformationFraudDto();
            informationFraudDto.BuildInformationFraudDto(ipResponse, countryResponse, currencyResponse);

            _fraudeQuery.Setup(x => x.GetInformationFraudeAsync(It.IsAny<string>()))
                        .ReturnsAsync(informationFraudDto);

            _IPService.Setup(x => x.GetIpByIpAsync(It.IsAny<string>()))
                       .ReturnsAsync(ipResponse)
                       .Verifiable();

            _CountryService.Setup(x => x.GetCountryByNameAsync(It.IsAny<string>()))
                       .ReturnsAsync(countryResponse)
                       .Verifiable();

            _CurrencyService.Setup(x => x.GetCurrencyByCodeAsync(It.IsAny<string>()))
                       .ReturnsAsync(currencyResponse)
                       .Verifiable();

            _CurrencyService.Setup(x => x.GetCurrencyByCodeAsync(It.IsAny<string>()))
                       .ReturnsAsync(currencyResponse)
                       .Verifiable();

            _fraudeRepository.Setup(x => x.AddFraudeAsync(It.IsAny<InformationFraudDto>()))
                             .Verifiable();

            informationFraudDto = new InformationFraudDto();
            informationFraudDto.BuildInformationFraudDto(ipResponse, countryResponse, currencyResponse);

            var response = await _fraudeService.GetInformationFraudeAsync(IP);

            Assert.NotNull(response);

            _fraudeQuery.Verify(
              mock => mock.GetInformationFraudeAsync(It.IsAny<string>()),
              Times.Once);

            _IPService.Verify(
             mock => mock.GetIpByIpAsync(It.IsAny<string>()),
             Times.Never);

            _CountryService.Verify(
             mock => mock.GetCountryByNameAsync(It.IsAny<string>()),
             Times.Never);
            _fraudeRepository.Verify(
            mock => mock.AddFraudeAsync(It.IsAny<InformationFraudDto>()),
            Times.Never);
        }

        [Fact(DisplayName = "VALIDATE_IP_RESPONSE_CALLBACK")]
        public void VALIDATE_IP_RESPONSE_CALLBACK()
        {
            IpResponse ipResponse = new IpResponse()
            {
                City = "",
                Country_Name = "",
                Ip = ""
            };

            var ex = Assert.Throws<GenericException>(() => _fraudeService.ValidateIpResponseCallBack(ipResponse));

            Assert.Contains(MessageGeneral.NotFound, ex.Message);
        }

        [Fact(DisplayName = "WHEN_IP_DONT_EXIST")]
        public async Task WHEN_IP_DONT_EXIST()
        {
            InformationFraudDto InformationFraudDto = null;

            IpResponse ipResponse = new IpResponse()
            {
                City = "",
                Country_Name = "",
                Ip = ""
            };

            _fraudeQuery.Setup(x => x.GetInformationFraudeAsync(It.IsAny<string>()))
                        .ReturnsAsync(InformationFraudDto);

            _IPService.Setup(x => x.GetIpByIpAsync(It.IsAny<string>()))
                       .ReturnsAsync(ipResponse)
                       .Verifiable();
            try
            {
                var response = _fraudeService.GetInformationFraudeAsync(IP);
            }
            catch (GenericException e)
            {
                Assert.Contains(MessageGeneral.NotFound, e.Message);
            }

            _fraudeQuery.Verify(
              mock => mock.GetInformationFraudeAsync(It.IsAny<string>()),
              Times.Once);

            _IPService.Verify(
             mock => mock.GetIpByIpAsync(It.IsAny<string>()),
             Times.Once);
        }

        private void BuildInformation(out IpResponse ipResponse, out CountryResponse countryResponse, out CurrencyResponse currencyResponse)
        {
            ipResponse = new IpResponse()
            {
                City = "Mar del Plata",
                Country_Name = "Argentina",
                Ip = IP,
                Latitude = -34.6083,
                Longitude = -58.3712,
                Location = new LocationResponse()
                {
                    Capital = "Buenos Aires",
                    Geoname_Id = "1-asd",
                    Languages = new System.Collections.Generic.List<LenguagesResponse>()
                    {
                        new LenguagesResponse()
                        {
                            Name = "Español",
                            Code = "ES",
                            Native = "SI"
                        }
                    }
                }
            };
            countryResponse = new CountryResponse()
            {
                Name = "Argentina",
                Alpha2Code = "AR",
                Alpha3Code = "ARG"
            };
            currencyResponse = new CurrencyResponse()
            {
                Currencies = new Currency()
                {
                    ARS = new ARS()
                    {

                        Name = "Pesos Argentinos",
                        Symbol = "$"

                    }
                }
            };
        }
    }
}
