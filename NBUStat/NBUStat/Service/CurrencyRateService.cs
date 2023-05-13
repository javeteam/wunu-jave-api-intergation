using System;
using System.Threading.Tasks;
using NBUStat.Api;
using NBUStat.Data;
using NBUStat.Data.Response;

namespace NBUStat.Service {
    public class CurrencyRateService : ICurrencyRateService {
        private readonly ICurrencyRateApi _currencyRateApi;

        public CurrencyRateService(ICurrencyRateApi currencyRateApi) {
            _currencyRateApi = currencyRateApi;
        }
        
        public async Task<IResponse<CurrencyRate[]>> GetCurrencyRatesAsync() {
            try {
                var response = await _currencyRateApi.GetCurrencyRatesAsync();
                if (response.IsSuccessStatusCode) {
                    return new SuccessResponse<CurrencyRate[]>(response.Content);
                }

                return new ErrorResponse<CurrencyRate[]>("Failed to get currency rates");
            } catch (Exception ex) {
                return new ErrorResponse<CurrencyRate[]>(ex.Message);
            }
        }
        
        public async Task<IResponse<CurrencyRate[]>> GetCurrencyRatesHistoryAsync(string currencyCode) {
            try {
                var start = DateTime.Now.AddDays(-28).ToString("yyyyMMdd");
                var end = DateTime.Now.ToString("yyyyMMdd");
                var response = await _currencyRateApi.GetCurrencyRatesHistoryAsync(currencyCode, start, end);
                if (response.IsSuccessStatusCode) {
                    return new SuccessResponse<CurrencyRate[]>(response.Content);
                }

                return new ErrorResponse<CurrencyRate[]>("Failed to get currency rates");
            } catch (Exception ex) {
                return new ErrorResponse<CurrencyRate[]>(ex.Message);
            }
        }
    }
}