using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BettingService.Tests.Domain;
using BettingService.Tests.Factories;

namespace BettingService.Tests.Services
{
    public class EventService
    {
        private readonly IProfitCalculatorService _profitCalculatorService;

        public EventService(IProfitCalculatorService profitCalculatorService)
        {
            _profitCalculatorService = profitCalculatorService;
        }
        public async Task<decimal> CalculateEventProfitAsync(Event bettingEvent)
        {
            var winningValidationStrategy = WinnningValidationStrategyFactory.GetStrategy(bettingEvent.EventSport);
            var winnerSelections = await winningValidationStrategy.GetWinningSelectionsAsync(bettingEvent);
            var winnerSelectionsHashset = new HashSet<Guid>(winnerSelections.Select(w => w.Id));
            return await _profitCalculatorService.CalculateAsync(bettingEvent, winnerSelectionsHashset);
        }
    }
}