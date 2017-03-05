using System.Linq;
using System.Threading.Tasks;
using BettingService.Tests.Factories;
using BettingServices.Domain;
using BettingServices.Domain.Strategies;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BettingService.Tests
{
    [TestClass]
    public class TennisWinningValidationStrategyTests
    {
        [TestMethod]
        public void GetWinningSelectionsAsync_TeamAWonOutright()
        {
            var tennisStrategy = new TennisWinningValidationStrategy();
            var outrightBetsEvent = EventFactory.CreateTennisEvent().WithScore(3, 0);
            var expectedSelections =
                outrightBetsEvent.Markets[0].Selections.Where(
                    s => s.WinningCondition.IsOutright && s.WinningCondition.TeamAWin).Select(s => s.Id);
            var selections = tennisStrategy.GetWinningSelections(outrightBetsEvent);

            Assert.IsTrue(selections.All(s => expectedSelections.Contains(s.Id)));
        }

        [TestMethod]
        public void GetWinningSelectionsAsync_TeamBWonOutright()
        {
            var tennisStrategy = new TennisWinningValidationStrategy();
            var outrightBetsEvent = EventFactory.CreateTennisEvent().WithScore(0, 3);
            var expectedSelections =
                outrightBetsEvent.Markets[0].Selections.Where(
                    s => s.WinningCondition.IsOutright && s.WinningCondition.TeamBWin).Select(s => s.Id);
            var selections = tennisStrategy.GetWinningSelections(outrightBetsEvent);

            Assert.IsTrue(selections.All(s => expectedSelections.Contains(s.Id)));
        }

        [TestMethod]
        public void GetWinningSelectionsAsync_TeamAWonSetTwoFirstGame()
        {
            var tennisStrategy = new TennisWinningValidationStrategy();
            var outrightBetsEvent = EventFactory.WithGame(EventFactory.CreateTennisEventSet2Game1Market(), 2, 1, true);
            var expectedSelections =
                outrightBetsEvent.Markets[0].Selections.Where(s =>
                    ((TennisCondition) s.WinningCondition.CustomCondition).GameNumber == 1 &&
                    ((TennisCondition) s.WinningCondition.CustomCondition).Player1Win).Select(s => s.Id);
            var selections = tennisStrategy.GetWinningSelections(outrightBetsEvent);

            Assert.IsTrue(selections.All(s => expectedSelections.Contains(s.Id)));
        }

        [TestMethod]
        public void GetWinningSelectionsAsync_TeamBWonSetTwoFirstGame()
        {
            var tennisStrategy = new TennisWinningValidationStrategy();
            var outrightBetsEvent = EventFactory.WithGame(EventFactory.CreateTennisEventSet2Game1Market(), 2, 1, false);
            var expectedSelections =
                outrightBetsEvent.Markets[0].Selections.Where(s =>
                    ((TennisCondition)s.WinningCondition.CustomCondition).GameNumber == 1 &&
                    !((TennisCondition)s.WinningCondition.CustomCondition).Player1Win).Select(s => s.Id);
            var selections = tennisStrategy.GetWinningSelections(outrightBetsEvent);

            Assert.IsTrue(selections.All(s => expectedSelections.Contains(s.Id)));
        }
    }
}