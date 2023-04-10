using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CryptoConsole
{
    internal static class DataFetcher
    {
        private const string url = @"https://api.wazirx.com/sapi/v1/tickers/24hr";
        private static readonly HttpClient s_httpClient = new HttpClient();
        private static readonly JsonSerializerOptions s_jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        public static async Task<List<CryptoDto>> Fetch()
        {
            var response = await s_httpClient.GetAsync(url);

            if(response == null || !response.IsSuccessStatusCode)
            {
                return new List<CryptoDto>();
            }

            var content = await response.Content.ReadAsStringAsync();//that works;)))
            //await Console.Out.WriteLineAsync(content);
            var deserializedDataList = JsonSerializer.Deserialize<List<Crypto>>(content, s_jsonSerializerOptions).ToList();
            var dtos = deserializedDataList.Select(crypto => new CryptoDto
            {
                Symbol = crypto.Symbol,
                BaseAsset = crypto.BaseAsset,
                QuoteAsset = crypto.QuoteAsset,
                OpenPrice = Convert.ToDouble(crypto.OpenPrice),
                LowPrice = Convert.ToDouble(crypto.LowPrice),
                HighPrice = Convert.ToDouble(crypto.HighPrice),
                LastPrice = Convert.ToDouble(crypto.LastPrice),
                Volume = Convert.ToDouble(crypto.Volume),
                BidPrice = Convert.ToDouble(crypto.BidPrice),
                AskPrice = Convert.ToDouble(crypto.AskPrice)
            }
            ).ToList();

            foreach( var d in dtos)
            {
                await Console.Out.WriteLineAsync(d.ToString());
            }

            return dtos;
        }
    }
}
