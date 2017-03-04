using BettingService.Tests.Domain;
using BettingService.Tests.Services;
using BettingService.Tests.Strategies;

namespace BettingService.Tests.Factories
{
    public class WinnningValidationStrategyFactory
    {
        public static IWinningValidationStrategy GetStrategy(Sport eventSport)
        {
            if(eventSport == Sport.Football)
                return new FootballWinningValidationStrategy();
            return new TennisWinningValidationStrategy();
        }
    }
}