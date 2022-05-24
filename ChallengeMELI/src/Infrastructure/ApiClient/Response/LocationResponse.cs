using System.Collections.Generic;

namespace Challenge.MELI.ApiClient.Response
{
    public class LocationResponse
    {
        public string Geoname_Id { get; set; }
        public string Capital { get; set; }
        public List<LenguagesResponse> Languages { get; set; }
    }
}
