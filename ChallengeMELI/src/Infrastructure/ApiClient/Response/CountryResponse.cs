using System.Collections.Generic;

namespace Challenge.MELI.ApiClient.Response
{
    public class CountryResponse
    {
        public string Name { get; set; }
        public string Alpha2Code { get; set; }
        public string Alpha3Code { get; set; }
        public List<string> CallingCodes { get; set; }
    }
}
