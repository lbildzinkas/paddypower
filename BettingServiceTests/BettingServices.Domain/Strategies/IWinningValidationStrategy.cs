using System.Collections.Generic;
using System.Threading.Tasks;

namespace BettingServices.Domain.Strategies
{
    public interface IWinningValidationStrategy
    {
        Task<IEnumerable<Selection>> GetWinningSelectionsAsync(Event bettingEvent);
    }
}