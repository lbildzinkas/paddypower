using System.Collections.Generic;
using System.Threading.Tasks;

namespace BettingServices.Domain.Strategies
{
    public interface IWinningValidationStrategy
    {
        IEnumerable<Selection> GetWinningSelections(Event bettingEvent);
    }
}