using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoBotStandard.Contracts
{
    public enum BotType
    {
        Rebalancer,
        Indicator
    }

    public enum TimeRate
    {
        Second,
        Minute,
        Hour,
        Day,
        Week,
        Month
    }
}
