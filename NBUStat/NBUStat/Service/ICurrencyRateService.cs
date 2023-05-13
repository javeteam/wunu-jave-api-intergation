using System.Threading.Tasks;
using NBUStat.Data;
using NBUStat.Data.Response;

namespace NBUStat.Service {
    public interface ICurrencyRateService {
        Task<IResponse<CurrencyRate[]>> GetCurrencyRatesAsync();
        Task<IResponse<CurrencyRate[]>> GetCurrencyRatesHistoryAsync(string isoCode);
    }
}