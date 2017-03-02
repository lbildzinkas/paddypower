using System.Threading.Tasks;

namespace BettingService.Tests
{
    public class ProfitCalculatorService
    {
        private readonly IEventCalculationStrategy _eventCalculationStrategy;

        public ProfitCalculatorService(IEventCalculationStrategy eventCalculationStrategy)
        {
            _eventCalculationStrategy = eventCalculationStrategy;
        }


        public async Task<double> CalculateAsync(IBettingEvent bettingEvent)
        {
            return await _eventCalculationStrategy.CalculateAsync(bettingEvent).ConfigureAwait(false);
        }
    }
}