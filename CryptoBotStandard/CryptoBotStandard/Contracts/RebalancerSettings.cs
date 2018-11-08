using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoBotStandard.Contracts
{
    public class RebalancerSettings : IBotSettings
    {
        public bool RunBot { get; set; }
        public Currency[] Currencies { get; set; }
        public Currency BaseCurrency { get; set; }
        public TimeRate TimeRate { get; set; }
        public int RebalanceInterval { get; set; }
        public ApiInformation ApiInformation { get; set; }
        public DayOfWeek? RunDay { get; set; }
        public int? RunHour { get; set; }
        public int? RunMinute { get; set; }
    }
}
