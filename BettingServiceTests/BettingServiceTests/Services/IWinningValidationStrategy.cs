using System.Collections.Generic;
using System.Threading.Tasks;
using BettingService.Tests.Domain;

namespace BettingService.Tests.Services
{
    public interface IWinningValidationStrategy
    {
        Task<IEnumerable<Selection>> GetWinningSelectionsAsync(Event bettingEvent);
    }
}