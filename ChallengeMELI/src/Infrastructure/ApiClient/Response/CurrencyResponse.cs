using System.Collections.Generic;

namespace Challenge.MELI.ApiClient.Response
{
    public class CurrencyResponse
    {
        public List<string> Timezones { get; set; }

        public Currency Currencies { get; set; }
    }

    public class Currency 
    {
       public ARS ARS { get; set; }
    }

    public class ARS 
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
    }
}
