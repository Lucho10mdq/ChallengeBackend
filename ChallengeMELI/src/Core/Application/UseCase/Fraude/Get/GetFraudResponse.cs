using Challenge.MELI.Domain;
using Challenge.MELI.Domain.Dtos;
using System;
using System.Collections.Generic;

namespace Challenge.MELI.Application.UseCase.Fraude.Get
{
    public class  GetFraudResponse
    {
        public string Ip { set; get; }
        public DateTime CurrentDate { set; get; }
        public string Country { set; get; }
        public string IsoCode { set; get; }
        public LocationDto Location { set; get; }
        public CurrencyDto Currencies { get; set; }
        public DateTime Hours { set; get; }
        public double Distance { set; get; }
        public string City { set; get; }

        public List<string> Timezones { set; get; }
        public GetFraudResponse(InformationFraudDto informationFraudeDto) 
        {
            Ip = informationFraudeDto.Ip;
            CurrentDate = DateTime.UtcNow.Date;
            Country = informationFraudeDto.Country;
            City = informationFraudeDto.City;
            Distance = informationFraudeDto.Distance;
            IsoCode = informationFraudeDto.IsoCode;
            Location = informationFraudeDto.Location;
            Currencies = informationFraudeDto.Currencies;
            
            Timezones = informationFraudeDto.Timezones;
    }
    }
}
