using System.Linq;
using System.Threading.Tasks;
using BettingService.Tests.Factories;
using BettingServices.Domain.Strategies;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BettingService.Tests
{
    [TestClass]
    public class FootballWinningValidationStrategyTests
    {
        [TestMethod]
        public void GetWinningSelectionsAsync_TeamAWonOutrightTest()
        {
            var footballStrategy = new FootballWinningValidationStrategy();
            var outrightBetsEvent = EventFactory.CreateFootballEvent().WithScore(1, 0);
            var expectedSelections =
                outrightBetsEvent.Markets[0].Selections.Where(
                    s => s.WinningCondition.IsOutright && s.WinningCondition.TeamAWin).Select(s => s.Id);
            var selections = footballStrategy.GetWinningSelections(outrightBetsEvent);

            Assert.IsTrue(selections.All(s => expectedSelections.Contains(s.Id)));
        }

        [TestMethod]
        public void GetWinningSelectionsAsync_TeamBWonOutrightTest()
        {
            var footballStrategy = new FootballWinningValidationStrategy();
            var outrightBetsEvent = EventFactory.CreateFootballEvent().WithScore(0, 1);
            var expectedSelections =
                outrightBetsEvent.Markets[0].Selections.Where(
                    s => s.WinningCondition.IsOutright && s.WinningCondition.TeamBWin).Select(s => s.Id);
            var selections = footballStrategy.GetWinningSelections(outrightBetsEvent);

            Assert.IsTrue(selections.All(s => expectedSelections.Contains(s.Id)));
        }

        [TestMethod]
        public void GetWinningSelectionsAsync_DrawOutrightTest()
        {
            var footballStrategy = new FootballWinningValidationStrategy();
            var outrightBetsEvent = EventFactory.CreateFootballEvent().WithScore(0, 0);
            var expectedSelections =
                outrightBetsEvent.Markets[0].Selections.Where(
                    s => s.WinningCondition.IsOutright && s.WinningCondition.Draw).Select(s => s.Id);
            var selections = footballStrategy.GetWinningSelections(outrightBetsEvent);

            Assert.IsTrue(selections.All(s => expectedSelections.Contains(s.Id)));
        }

        [TestMethod]
        public void GetWinningSelectionsAsync_TeamAWonForOneScoreTest()
        {
            var footballStrategy = new FootballWinningValidationStrategy();
            var outrightBetsEvent = EventFactory.CreateFootballEventScoreMarket().WithScore(1, 0);
            var expectedSelections =
                outrightBetsEvent.Markets[0].Selections.Where(
                    s => s.WinningCondition.TeamAWin && s.WinningCondition.TeamAScore == 1
                    && s.WinningCondition.TeamBScore == 0).Select(s => s.Id);
            var selections = footballStrategy.GetWinningSelections(outrightBetsEvent);

            Assert.IsTrue(selections.All(s => expectedSelections.Contains(s.Id)));
        }

        [TestMethod]
        public void GetWinningSelectionsAsync_TeamBWonForOneScoreTest()
        {
            var footballStrategy = new FootballWinningValidationStrategy();
            var outrightBetsEvent = EventFactory.CreateFootballEventScoreMarket().WithScore(0, 1);
            var expectedSelections =
                outrightBetsEvent.Markets[0].Selections.Where(
                    s => s.WinningCondition.TeamBWin && s.WinningCondition.TeamAScore == 0
                    && s.WinningCondition.TeamBScore == 1).Select(s => s.Id);
            var selections = footballStrategy.GetWinningSelections(outrightBetsEvent);

            Assert.IsTrue(selections.All(s => expectedSelections.Contains(s.Id)));
        }

        [TestMethod]
        public void GetWinningSelectionsAsync_DrawNoGoalsScoreTest()
        {
            var footballStrategy = new FootballWinningValidationStrategy();
            var outrightBetsEvent = EventFactory.CreateFootballEventScoreMarket().WithScore(0, 0);
            var expectedSelections =
                outrightBetsEvent.Markets[0].Selections.Where(
                    s => s.WinningCondition.Draw && s.WinningCondition.TeamAScore == 0
                    && s.WinningCondition.TeamBScore == 0).Select(s => s.Id);
            var selections = footballStrategy.GetWinningSelections(outrightBetsEvent);

            Assert.IsTrue(selections.All(s => expectedSelections.Contains(s.Id)));
        }

        [TestMethod]
        public void GetWinningSelectionsAsync_BothMarketsTeamAWonForOne()
        {
            var footballStrategy = new FootballWinningValidationStrategy();
            var outrightBetsEvent = EventFactory.CreateFootballEventTwoMarkets().WithScore(1, 0);
            var expectedSelections =
                outrightBetsEvent.Markets[0].Selections.Where(
                    s => s.WinningCondition.IsOutright && s.WinningCondition.TeamAWin).Select(s => s.Id).ToList();
            expectedSelections.AddRange(outrightBetsEvent.Markets[1].Selections.Where(
                    s => s.WinningCondition.TeamAWin && s.WinningCondition.TeamAScore == 1
                    && s.WinningCondition.TeamBScore == 0).Select(s => s.Id).ToList());
            var selections = footballStrategy.GetWinningSelections(outrightBetsEvent);

            Assert.IsTrue(selections.All(s => expectedSelections.Contains(s.Id)));
        }
    }
}
