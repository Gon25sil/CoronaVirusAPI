using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaVirus.Models
{
    public class CoronaVirusCountry
    {
        public string CountryName { get; set; }
        public int CaseCount  { get; set; }
        public string FlagUri { get; set; }

        public int Recovered { get; set; }
        public int Deaths { get; set; }
        public int Active { get; set; }
        public int Critical { get; set; }
        public int TodayDeaths { get; set; }



    }
}
