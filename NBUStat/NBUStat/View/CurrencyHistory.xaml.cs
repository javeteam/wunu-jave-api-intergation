using NBUStat.Factory;
using NBUStat.Service;
using NBUStat.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace NBUStat.View {
    public partial class CurrencyHistory : ContentPage {
        public CurrencyHistory(string isoCode) {
            InitializeComponent();

            On<iOS>().SetUseSafeArea(true);

            var currencyRateApi = CurrencyRateApiFactory.Create();
            var currencyRateService = new CurrencyRateService(currencyRateApi);
            BindingContext = new CurrencyHistoryViewModel(currencyRateService, isoCode);
        }
    }
}