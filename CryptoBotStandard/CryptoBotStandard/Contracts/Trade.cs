using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoBotStandard.Contracts
{
    public class Trade
    {
        public string TradingPair { get; set; }
        public Currency BuyCurrency { get; set; }
        public Currency SellCurrency { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime TradeDate { get; set; }
        public Exchange Exchange { get; set; }
    }
}
