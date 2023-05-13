using System;
using System.Threading.Tasks;
using NBUStat.Data;
using Refit;

namespace NBUStat.Api {
    public interface ICurrencyRateApi {
        [Get("/NBUStatService/v1/statdirectory/exchange")]
        Task<ApiResponse<CurrencyRate[]>> GetCurrencyRatesAsync([AliasAs("json")] string json = "true");
        
        [Get("/NBU_Exchange/exchange_site")]
        Task<ApiResponse<CurrencyRate[]>> GetCurrencyRatesHistoryAsync(
            [AliasAs("valcode")] string isoCode,
            [AliasAs("start")] string start,
            [AliasAs("end")] string end,
            [AliasAs("sort")] string sort = "exchangedate",
            [AliasAs("order")] string order = "desc",
            [AliasAs("json")] string json = "true"
            );
    }
}