using CryptoBotStandard.Contracts;
using CryptoBotStandard.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoBotStandard.Builders
{
    public class RebalancerBot : IBotBase, IRebalancerBot
    {
        private RebalancerSettings _settings;
        private int _timer;
        private bool _runBot;

        public RebalancerBot(RebalancerSettings settings)
        {
            this._settings = settings;
            this._runBot = settings.RunBot;
            this._timer = GetTimerLength(_settings.TimeRate);
        }

        public int RunBot()
        {
            while (_runBot)
            {
                Task.WaitAll(Task.Delay(_timer));
                if (ValidateRunTime() && GetBotStatus())
                {
                    ExecuteTrades();
                }
            }
            return 0;
        }

        private int ExecuteTrades()
        {
            var rebalanceEvent = new RebalanceEvent();
            var coinCount = _settings.Currencies.Length;
            var balances = GetInitialBalances(_settings.Currencies);
            rebalanceEvent.Balances = balances;
            rebalanceEvent.StartTime = DateTime.UtcNow;
            foreach (var currency in _settings.Currencies)
            {
                var price = SellToBase(currency);
                var thisBalance = rebalanceEvent.Balances.Where(b => b.Currency.Symbol.Equals(currency.Symbol)).FirstOrDefault();
                thisBalance.Price = price;
            }
            var baseBalance = GetBaseBalance();
            rebalanceEvent.BaseQuantity = baseBalance;
            var baseBuyLimit = GetBaseBuyLimit(baseBalance, coinCount);
            foreach(var currency in _settings.Currencies)
            {
                var quantity = Rebuy(currency, baseBuyLimit);
                var thisBalance = rebalanceEvent.Balances.Where(b => b.Currency.Symbol.Equals(currency.Symbol)).FirstOrDefault();
                thisBalance.FinalQuantity = quantity;
            }
            rebalanceEvent.EndTime = DateTime.UtcNow;
            CaptureRebalanceTrip(rebalanceEvent);
            return 0;
        }

        private decimal SellToBase(Currency currency)
        {
            if (currency.Symbol.Equals(_settings.BaseCurrency.Symbol))
            {
                return 0.0M; //return usdt or btc value
            }
            // place and validate sell order
            return 0.0M;// return sell price
        }

        private Balance[] GetInitialBalances(Currency[] currencies)
        {
            var exchangeBalances = new List<Balance>();/// Get balances from exchange
            var balances = new List<Balance>(); 

            foreach(var currency in currencies)
            {
                var thisBalance = exchangeBalances.Where(e => e.Currency.Symbol.Equals(currency.Symbol)).FirstOrDefault();
                var balance = new Balance
                {
                    Currency = currency,
                    StartingQuantity = thisBalance.StartingQuantity,
                };
                balances.Add(balance);
            }

            return balances.ToArray();
        }

        private decimal GetBaseBalance()
        {
            /// Get balance from exchange
            return 0.0M;
        }

        private decimal GetBaseBuyLimit(decimal baseBalance, int coinCount)
        {
            return baseBalance / coinCount;
        }

        private decimal Rebuy(Currency currency, decimal baseQuantity)
        {
            if (currency.Symbol.Equals(_settings.BaseCurrency.Symbol))
            {
                return baseQuantity; //return usdt or btc value
            }
            // place and validate buy order
            return 0.0M; //return quantity bought
        }

        private void CaptureRebalanceTrip(RebalanceEvent rebalanceEvent)
        {
            // save rebalance trip
        }

        private int GetTimerLength(TimeRate timeRate)
        {
            switch (timeRate)
            {
                case TimeRate.Millisecond:
                    return 1;
                case TimeRate.Centisecond:
                    return 100;
                case TimeRate.Second:
                    return 1000;
                case TimeRate.Minute:
                    return 60000;
                case TimeRate.Hour:
                    return 3600000;
                case TimeRate.Day:
                    return 86400000;
                default:
                    return 1000;
            }
        }

        private bool GetBotStatus()
        {
            /// Get updated settings from some source...
            return true;
        }

        private bool ValidateRunTime()
        {
            var now = DateTime.UtcNow;
            var run = true;

            if(_settings.RunDay != null)
            {
                if(_settings.RunDay != now.DayOfWeek)
                {
                    run = false;
                }
            }

            if(_settings.RunHour != null)
            {
                if (now.Hour != (int)_settings.RunHour)
                {
                    run = false;
                }
            }

            if(_settings.RunMinute != null)
            {
                if(now.Minute != (int)_settings.RunMinute)
                {
                    run = false;
                }
            }

            return run;
        }
    }
}
