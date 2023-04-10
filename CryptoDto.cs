using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoConsole
{
    internal class CryptoDto
    {
        public string? Symbol { get; set; }
        public string? BaseAsset { get; set; }
        public string? QuoteAsset { get; set; }
        public double OpenPrice { get; set; }
        public double LowPrice { get; set; }
        public double HighPrice { get; set; }
        public double LastPrice { get; set; }
        public double Volume { get; set; }
        public double BidPrice { get; set; }
        public double AskPrice { get; set; }

        public override string ToString()
        {
            return $"Symbol: {Symbol},\nBaseAsset: {BaseAsset},\nQuoteAsset: {QuoteAsset},\nOpenPrice: {OpenPrice},\nLowPrice: {LowPrice},\nHighPrice: {HighPrice},\nLastPrice: {LastPrice},\nVolume: {Volume},\nBidPrice: {BidPrice},\nAskPrice: {AskPrice}\n\n";
        }

    }
}
