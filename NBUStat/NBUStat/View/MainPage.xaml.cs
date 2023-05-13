using System;
using NBUStat.Data;
using NBUStat.Factory;
using NBUStat.Service;
using NBUStat.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace NBUStat.View {
    public partial class MainPage : ContentPage {
        public MainPage() {
            InitializeComponent();

            On<iOS>().SetUseSafeArea(true);

            var currencyRateApi = CurrencyRateApiFactory.Create();
            var currencyRateService = new CurrencyRateService(currencyRateApi);
            BindingContext = new MainPageViewModel(currencyRateService);
        }

        private void TapGestureRecognizer_OnTapped(object sender, EventArgs e) {
            var grid = sender as Grid;
            if (grid != null) {
                var context = grid.BindingContext as CurrencyRate;
                if (context != null) {
                    Navigation.PushAsync(new CurrencyHistory(context.IsoCode));
                }
            }
        }
    }
}