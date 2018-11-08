using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoBotStandard.Contracts
{
    public class Balance
    {
        public Currency Currency { get; set; }
        public decimal StartingQuantity { get; set; }
        public decimal FinalQuantity { get; set; }
        public decimal Price { get; set; }
        public double PercentDiff { get; set; }
    }
}
