using CoronaVirus.Models.Services;
using CoronaVirus.Services.API;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaVirus.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        private readonly int AMOUNT_OF_CASES = 10;

        private readonly ICoronavirusCountryService _coronavirusCountryService;
        private IEnumerable<Models.CoronaVirusCountry> _coronaData { get; set; }

        private IPageViewModel currentPageViewModel;

        public IPageViewModel CurrentPageViewModel
        {
            get { return currentPageViewModel; }
            set
            {
                currentPageViewModel = value;
                OnPropertyChanged(nameof(CurrentPageViewModel));
            }
        }

        private List<IPageViewModel> pageViewModels;

        public List<IPageViewModel> PageViewModels
        {
            get
            {
                if (pageViewModels == null)
                    pageViewModels = new List<IPageViewModel>();
                return pageViewModels;
            }
        }
        private void OnGo1Screen(object obj)
        {
            ChangeViewModel(PageViewModels[0]);
        }

        private void OnGo2Screen(object obj)
        {
            if (obj is ChartPoint p)
            {
                int pos = Convert.ToInt32(p.X);

                if (PageViewModels[1] is CoronaCountryInformationViewModel informationViewModel)
                {
                    informationViewModel.LoadData(_coronaData.ElementAt(pos).CountryName,
                                                        _coronaData.ElementAt(pos).FlagUri,
                                                        _coronaData.ElementAt(pos).Recovered, _coronaData.ElementAt(pos).Deaths,
                                                        _coronaData.ElementAt(pos).CaseCount,
                                                        _coronaData.ElementAt(pos).TodayDeaths,
                                                        _coronaData.ElementAt(pos).Active,
                                                        _coronaData.ElementAt(pos).Critical);
                }

                ChangeViewModel(PageViewModels[1]);
            }
        }

        private void ChangeViewModel(IPageViewModel viewModel)
        {
            CurrentPageViewModel = viewModel;
        }
        public MainViewModel(CoronaCountriesViewModel coronaCountriesViewModel,
                             CoronaCountryInformationViewModel coronaCountryInformationViewModel)
        {
            _coronavirusCountryService = new APICoronavirusCountryService();

            PageViewModels.Add(coronaCountriesViewModel);
            PageViewModels.Add(coronaCountryInformationViewModel);

            Mediator.Subscribe("GoTo1Screen", OnGo1Screen);
            Mediator.Subscribe("GoTo2Screen", OnGo2Screen);

        }

        public void LoadData()
        {
            Load().ContinueWith(OnLoadCompleted);
        }

        private void OnLoadCompleted(Task task)
        {
            try
            {
                ((CoronaCountriesViewModel)(PageViewModels.First(x => x is CoronaCountriesViewModel))).Load(_coronaData);
            }
            catch (Exception e)
            {
                throw new Exception("Error loading views");
            }

            CurrentPageViewModel = PageViewModels[0];
        }

        private async Task Load()
        {
            _coronaData = await _coronavirusCountryService.GetTopCases(AMOUNT_OF_CASES);
        }


    }
}
