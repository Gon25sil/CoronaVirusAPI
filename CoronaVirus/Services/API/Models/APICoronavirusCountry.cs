﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaVirus.Services.API.Models
{
    public class APICoronavirusCountry
    {
        public string Country { get; set; }
        public int Cases { get; set; }
        public int Recovered { get; set; }
        public int Deaths { get; set; }

        public int Active { get; set; }
        public int Critical { get; set; }
        public int TodayDeaths { get; set; }

        public APICoronavirusCountryInfo CountryInfo { get; set; }
    }
}
