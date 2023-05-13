using System.Text.Json.Serialization;

namespace NBUStat.Data {
    public class CurrencyRate {
        [JsonPropertyName("r030")]
        public int Code { get; set; }
        
        [JsonPropertyName("txt")]
        public string Name { get; set; }
        
        [JsonPropertyName("rate")]
        public double ExchangeRate { get; set; }
        
        [JsonPropertyName("cc")]
        public string IsoCode { get; set; }
        
        [JsonPropertyName("exchangedate")]
        public string Date { get; set; }
    }
}