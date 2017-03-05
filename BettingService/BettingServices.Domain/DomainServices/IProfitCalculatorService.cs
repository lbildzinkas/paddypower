using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BettingServices.Domain.DomainServices
{
    public interface IProfitCalculatorService
    {
        Task<decimal> CalculateAsync(Event bettingEvent, HashSet<Guid> winnerSelections);
    }
}