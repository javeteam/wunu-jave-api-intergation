using NBUStat.Api;
using Refit;

namespace NBUStat.Factory {
    public static class CurrencyRateApiFactory {
        private const string ApiUrl = "https://bank.gov.ua";
        
        public static ICurrencyRateApi Create() {
            return RestService.For<ICurrencyRateApi>(ApiUrl);
        }
    }
}