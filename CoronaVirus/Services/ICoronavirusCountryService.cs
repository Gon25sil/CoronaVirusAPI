using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoronaVirus.Models.Services
{
    public interface ICoronavirusCountryService
    {
        Task<IEnumerable<CoronaVirusCountry>> GetTopCases(int amountOfCountries);
    }
}
