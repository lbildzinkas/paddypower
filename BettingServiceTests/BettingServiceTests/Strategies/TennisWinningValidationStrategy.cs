using System.Collections.Generic;
using System.Threading.Tasks;
using BettingService.Tests.Domain;
using BettingService.Tests.Services;

namespace BettingService.Tests.Strategies
{
    public class TennisWinningValidationStrategy : IWinningValidationStrategy
    {
        public Task<IEnumerable<Selection>> GetWinningSelectionsAsync(Event bettingEvent)
        {
            throw new System.NotImplementedException();
        }
    }
}