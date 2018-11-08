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
        Millisecond,
        Centisecond,
        Second,
        Minute,
        Hour,
        Day,
        Week,
        Month
    }

    public enum Exchange
    {
        Binance,
        Bittrex,
        CoinbasePro,
        KuCoin
    }

}
