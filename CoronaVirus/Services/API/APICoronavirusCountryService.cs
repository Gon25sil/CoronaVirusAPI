using CoronaVirus.Models;
using CoronaVirus.Models.Services;
using CoronaVirus.Services.API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CoronaVirus.Services.API
{
    public class APICoronavirusCountryService : ICoronavirusCountryService
    {
        public async Task<IEnumerable<CoronaVirusCountry>> GetTopCases(int amountOfCountries)
        {
            using (HttpClient client = new HttpClient())
            {
                string requestUri = "https://corona.lmao.ninja/v3/covid-19/countries?sort=cases";
                HttpResponseMessage httpResponseMessage = await client.GetAsync(requestUri);

                string jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();

                List<APICoronavirusCountry> apiCountries = JsonSerializer.Deserialize<List<APICoronavirusCountry>>(jsonResponse, new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });

                return apiCountries.Take(amountOfCountries).Select(x => new CoronaVirusCountry()
                    {
                    CaseCount=x.Cases,
                    CountryName=x.Country,
                    FlagUri=x.CountryInfo.Flag,
                    Deaths = x.Deaths,
                    Recovered=x.Recovered,
                    Active=x.Active,
                    Critical=x.Critical,
                    TodayDeaths = x.TodayDeaths
                    }
                );
            }
        }
    }
}
