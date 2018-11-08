using CryptoBotStandard.Contracts;
using CryptoBotStandard.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoBotStandard.Builders
{
    public class BotRunner : IBotRunner
    {
        private IBotBase bot;

        public BotRunner()
        {

        }

        public void SetupBot(BotType botType, IBotSettings settings)
        {
            switch(botType)
            {
                case BotType.Indicator:
                    bot = new IndicatorBot((IndicatorSettings)settings);
                    break;
                case BotType.Rebalancer:
                    bot = new RebalancerBot((RebalancerSettings)settings);
                    break;
            }
        }
    }
}
