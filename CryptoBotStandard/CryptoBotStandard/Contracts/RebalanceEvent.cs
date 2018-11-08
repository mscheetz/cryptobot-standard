using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoBotStandard.Contracts
{
    public class RebalanceEvent
    {
        public Balance[] Balances { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Currency BaseCurrency { get; set; }
        public decimal BaseQuantity { get; set; }
    }
}