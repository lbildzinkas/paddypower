using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BettingService.Tests.Factories;
using BettingServices.Domain.DomainServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BettingService.Tests
{
    [TestClass]
    public class ProfitCalculatorServiceTests
    {
        [TestMethod]
        public async Task CalculateAsync_SimpleEventShouldCalculateCorrectAmount()
        {
            //Arrange
            decimal expectedProfit = -18.5m;
            var profitCalculatorService = new ProfitCalculatorService();
            var bettingEvent = EventFactory.CreateFootballEvent();
            var winnerSelections = new HashSet<Guid> {bettingEvent.Markets[0].Selections[0].Id};

            //Act
            var totalAmount = await profitCalculatorService.CalculateAsync(bettingEvent, winnerSelections);

            //Assert
            Assert.AreEqual(expectedProfit, totalAmount);
        }
    }
}
