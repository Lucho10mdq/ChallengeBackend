using System.Collections.Generic;

namespace Challenge.MELI.ApiClient.Response
{
    public class IpResponse
    {
        public string Ip { get; set; }
        public string Country_Name { get; set; }

        public string City { set; get; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public List<LenguagesResponse> Languages { get; set; }
        public LocationResponse Location { get; set; }

    }
}
