using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    internal class Crypto
    {
        public string Symbol { get; set; }
        public string BaseAsset { get; set; }
        public string QuoteAsset { get; set; }
        public string OpenPrice { get; set; }
        public string LowPrice { get; set; }
        public string HighPrice { get; set; }
        public string LastPrice { get; set; }
        public string Volume { get; set; }
        public string BidPrice { get; set; }
        public string AskPrice { get; set; }
        public long At { get; set; }

        public override string ToString()
        {
            return $"Symbol: {Symbol},\nBaseAsset: {BaseAsset},\nQuoteAsset: {QuoteAsset},\nOpenPrice: {OpenPrice},\nLowPrice: {LowPrice},\nHighPrice: {HighPrice},\nLastPrice: {LastPrice},\nVolume: {Volume},\nBidPrice: {BidPrice},\nAskPrice: {AskPrice},\nAt: {At}\n\n";
        }
    }
}
