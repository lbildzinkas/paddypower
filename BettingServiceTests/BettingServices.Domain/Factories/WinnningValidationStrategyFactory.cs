using BettingService.Tests.Strategies;
using BettingServices.Domain.Strategies;

namespace BettingServices.Domain.Factories
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