using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BettingService.Tests
{
    [TestClass]
    public class ProfitCalculatorServiceTests
    {
        [TestMethod]
        public async Task CalculatingProfitEventCalculationStrategyShouldBeCalled()
        {
            //Arrange
            var eventCalculationStrategy = new Mock<IEventCalculationStrategy>();
            var profitCalculatorService = new ProfitCalculatorService(eventCalculationStrategy.Object);
            var bettingEvent = new Mock<IBettingEvent>();

            //Act
            var totalAmount = await profitCalculatorService.CalculateAsync(bettingEvent.Object).ConfigureAwait(false);

            //Assert
            eventCalculationStrategy.Verify(e => e.CalculateAsync(It.IsAny<IBettingEvent>()), Times.Once());
        }
    }

    public interface IBettingEvent
    {
    }

    public interface IEventCalculationStrategy
    {
        Task<double> CalculateAsync(IBettingEvent eventCalculationStrategy);
    }
}
