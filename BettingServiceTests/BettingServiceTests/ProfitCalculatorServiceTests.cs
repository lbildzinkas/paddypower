using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BettingService.Tests.Domain;
using BettingService.Tests.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

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
            var bettingEvent = CreateNewEvent();
            var winnerSelections = new HashSet<Guid>();
            winnerSelections.Add(bettingEvent.Markets[0].Selections[0].Id);

            //Act
            var totalAmount = await profitCalculatorService.CalculateAsync(bettingEvent, winnerSelections);

            //Assert
            Assert.AreEqual(expectedProfit, totalAmount);
        }

        private Event CreateNewEvent()
        {
            var selections = new List<Selection>()
            {
                new Selection()
                {
                    Id = Guid.NewGuid(),
                    Odd = new FractionOdd(11, 4),
                    WinningCondition = new WinningCondition()
                    {
                        IsOutright = true,
                        TeamAWin = true
                    }
                },
                new Selection()
                {
                    Id = Guid.NewGuid(),
                    Odd = new FractionOdd(13, 5),
                    WinningCondition = new WinningCondition()
                    {
                        IsOutright = true,
                        TeamBWin = true
                    }
                }
                ,
                new Selection()
                {
                    Id = Guid.NewGuid(),
                    Odd = new FractionOdd(4, 6),
                    WinningCondition = new WinningCondition()
                    {
                        IsOutright = true,
                        Draw = true
                    }
                }
            };

            var outrightMarket = new Market()
            {
              Id = Guid.NewGuid(),
              Selections = selections
            };

            
            var bettingEvent = new Event("Paddy Power Cup Final", Sport.Football);
            bettingEvent.Markets = new List<Market>();
            bettingEvent.Markets.Add(outrightMarket);

            var bets = new List<Bet>()
            {
                new Bet()
                {
                    BetAmmount = 4,
                    SelectionBet = selections[0],
                    EventId = bettingEvent.Id,
                    Punter = new Punter() {Balance = 50,Id = Guid.NewGuid() }
                },
                new Bet()
                {
                    BetAmmount = 4,
                    SelectionBet = selections[2],
                    EventId = bettingEvent.Id,
                    Punter = new Punter() {Balance = 50,Id = Guid.NewGuid() }
                },
                new Bet()
                {
                    BetAmmount = 2,
                    SelectionBet = selections[0],
                    EventId = bettingEvent.Id,
                    Punter = new Punter() {Balance = 50,Id = Guid.NewGuid() }
                },
            };
            
            bettingEvent.Bets = bets;
            return bettingEvent;
        }
    }
}
