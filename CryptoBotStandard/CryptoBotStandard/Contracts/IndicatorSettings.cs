using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoBotStandard.Contracts
{
    public class IndicatorSettings
    {
        public ApiInformation ApiInformation { get; set; }
        public string TradingPair { get; set; }
        public decimal BuyTrigger { get; set; }
        public decimal SellTrigger { get; set; }
        public TimeRate TimeRate { get; set; }
        public int TimeInterval { get; set; }
    }
}
