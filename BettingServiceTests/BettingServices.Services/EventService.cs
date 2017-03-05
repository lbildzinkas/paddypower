using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BettingServices.Domain;
using BettingServices.Domain.DomainServices;
using BettingServices.Domain.Factories;

namespace BettingServices.Services
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