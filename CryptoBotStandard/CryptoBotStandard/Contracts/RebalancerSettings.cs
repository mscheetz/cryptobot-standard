using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoBotStandard.Contracts
{
    public class RebalancerSettings : IBotSettings
    {
        public string[] Pairs { get; set; }
        public TimeRate TimeRate { get; set; }
        public int RebalanceInterval { get; set; }
        public ApiInformation ApiInformation { get; set; }
    }
}
