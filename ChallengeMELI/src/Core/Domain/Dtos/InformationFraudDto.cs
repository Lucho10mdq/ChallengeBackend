using Challenge.MELI.ApiClient.Response;
using Challenge.MELI.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Challenge.MELI.Domain
{
    public class InformationFraudDto
    {
        public string Ip { set; get; }
        public DateTime CurrentDate { set; get; }
        public string Country { set; get; }
        public string City { set; get; }
        public string IsoCode { set; get; }
        public LocationDto Location { set; get; }
        public IList<CurrencyDto> Currencies { set; get; }
        public DateTime Hours { set; get; }
        public double Distance { set; get; }

        public void BuildInformationFraudDto(IpResponse  ipCountryResponse, CountryResponse countryReponse) 
        {
            Ip = ipCountryResponse.Ip;
            Country = ipCountryResponse.Country_Name;
            City = ipCountryResponse.City;
            IsoCode = countryReponse.Alpha3Code;
            Location = new LocationDto()
            {
                Capital = ipCountryResponse.Location.Capital,
                GeonameId = ipCountryResponse.Location.Geoname_Id,
                Languages = ipCountryResponse.Location.Languages.Select(x => new LenguageDto()
                {
                    Code = x.Code,
                    Name =
                    x.Name,
                    Native = x.Native
                }).ToList()
            };

            Distance = CalculateDistance(ipCountryResponse.Latitude, ipCountryResponse.Longitude);
        }

        public double CalculateDistance(double latitude, double longitud ) 
        {
            const double LAT_BA = -34.6083;
            const double LONG_BA = -58.3712;

            double radioEarth = 6371;

            var difLatitud = ToRadian(latitude - LAT_BA);
            var difLongitud = ToRadian(longitud - LONG_BA);

            var a =
                  Math.Sin(difLatitud / 2) * Math.Sin(difLatitud / 2) +
                  Math.Cos(ToRadian(LAT_BA)) * Math.Cos(ToRadian(latitude)) *
                  Math.Sin(difLongitud / 2) * Math.Sin(difLongitud / 2);
      
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var distanceKm = radioEarth * c;
            return distanceKm;     
        }

        public double ToRadian(double valor)
        {
            return Convert.ToSingle(Math.PI / 180) * valor;
        }
    }
}
