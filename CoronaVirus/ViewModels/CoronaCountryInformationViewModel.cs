using CoronaVirus.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace CoronaVirus.ViewModels
{
    public class CoronaCountryInformationViewModel : ViewModelBase, IPageViewModel
    {
        private string countryName;

        public string CountryName
        {
            get { return countryName; }
            set { countryName = value; OnPropertyChanged(nameof(CountryName)); }
        }

        private string flagUri;

        public string FlagUri
        {
            get { return flagUri; }
            set { flagUri = value; OnPropertyChanged(nameof(FlagUri)); }
        }

        private int totalDeaths;

        public int TotalDeaths
        {
            get { return totalDeaths; }
            set { totalDeaths = value; OnPropertyChanged(nameof(TotalDeaths)); }
        }

        private int totalCases;

        public int TotalCases
        {
            get { return totalCases; }
            set { totalCases = value; OnPropertyChanged(nameof(TotalCases)); }
        }

        private int active;

        public int Active
        {
            get { return active; }
            set { active = value; OnPropertyChanged(nameof(Active)); }
        }

        private int critical;

        public int Critical
        {
            get { return critical; }
            set { critical = value; OnPropertyChanged(nameof(Critical)); }
        }

        private int todayDeaths;

        public int TodayDeaths
        {
            get { return todayDeaths; }
            set { todayDeaths = value; OnPropertyChanged(nameof(TodayDeaths)); }
        }

        private int recovered;

        public int Recovered
        {
            get { return recovered; }
            set { recovered = value; OnPropertyChanged(nameof(Recovered)); }
        }


        private ICommand goToMainView;

        public ICommand GoToMainView
        {
            get
            {
                return goToMainView ?? (goToMainView = new DataClickCommand(x =>
                {
                    Mediator.Notify("GoTo1Screen", "");
                }));
            }
        }

        public void LoadData(string name, string flagUrI, int recovered, int deaths, int cases, int todayDeaths, int active, int critical)
        {
            CountryName = name;
            FlagUri = flagUrI;
            Recovered = recovered;
            TotalDeaths = deaths;
            TotalCases = cases;
            TodayDeaths = todayDeaths;
            Active = active;
            Critical = critical;
        }
    }
}
