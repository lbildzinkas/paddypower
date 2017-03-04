using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BettingService.Tests.Domain;

namespace BettingService.Tests.Services
{
    public interface IProfitCalculatorService
    {
        Task<decimal> CalculateAsync(Event bettingEvent, HashSet<Guid> winnerSelections);
    }
}