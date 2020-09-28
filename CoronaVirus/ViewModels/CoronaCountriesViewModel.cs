using CoronaVirus.Commands;
using CoronaVirus.Models;
using CoronaVirus.Models.Services;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CoronaVirus.ViewModels
{
    public class CoronaCountriesViewModel : ViewModelBase, IPageViewModel
    {

        private ICommand dataClickCommand;

        public ICommand DataClickCommand
        {
            get
            {
                return dataClickCommand ?? (dataClickCommand = new DataClickCommand(x =>
                {
                    Mediator.Notify("GoTo2Screen", x);
                }));
            }
        }
        public void Load(IEnumerable<CoronaVirusCountry> coronaData)
        {
            NumberCases = new ChartValues<int>(coronaData.Select(x => x.CaseCount));
            CountryNames = new ObservableCollection<string>(coronaData.Select(x => x.CountryName));
        }

        private ChartValues<int> numberCases;

        public ChartValues<int> NumberCases
        {
            get { return numberCases; }
            private set { numberCases = value; OnPropertyChanged(nameof(NumberCases)); }
        }

        public ObservableCollection<string> CountryNames { get; private set; }


    }
}
