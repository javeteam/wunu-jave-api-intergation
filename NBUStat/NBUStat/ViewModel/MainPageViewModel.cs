using System.Threading.Tasks;
using NBUStat.Data;
using NBUStat.Data.Response;
using NBUStat.Service;
using Xamarin.CommunityToolkit.ObjectModel;

namespace NBUStat.ViewModel {
    public class MainPageViewModel : ObservableObject {
        private readonly ICurrencyRateService _currencyRateService;

        private CurrencyRate[] _currencyRates;
        private string _errorMessage;

        public MainPageViewModel(ICurrencyRateService currencyRateService) {
            _currencyRateService = currencyRateService;

            Task.Run(InitAsync);
        }

        public CurrencyRate[] CurrencyRates {
            get => _currencyRates;
            set => SetProperty(ref _currencyRates, value);
        }

        public string ErrorMessage {
            get => _errorMessage;
            set => SetProperty(ref _errorMessage, value);
        }

        public async Task InitAsync() {
            var response = await _currencyRateService.GetCurrencyRatesAsync();
            if(response is ErrorResponse<CurrencyRate[]>) {
                ErrorMessage = response.ErrorMessage;
            } else {
                CurrencyRates = response.Content;
            }
        }
    }
}