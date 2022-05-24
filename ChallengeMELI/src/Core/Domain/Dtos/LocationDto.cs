using System.Collections.Generic;

namespace Challenge.MELI.Domain.Dtos
{
    public class LocationDto
    {
        public string GeonameId { get; set; }
        public string Capital { get; set; }
        public List<LenguageDto> Languages { get; set; }
    }
}
