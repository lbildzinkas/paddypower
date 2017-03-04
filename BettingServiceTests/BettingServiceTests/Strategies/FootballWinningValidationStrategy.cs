using System.Collections.Generic;
using System.Threading.Tasks;
using BettingService.Tests.Domain;
using BettingService.Tests.Services;

namespace BettingService.Tests.Strategies
{
    public class FootballWinningValidationStrategy : IWinningValidationStrategy
    {
        public async Task<IEnumerable<Selection>> GetWinningSelectionsAsync(Event bettingEvent)
        {
            return await Task.Run(() =>
            {
                var winnerSelections = new List<Selection>();
                var results = bettingEvent.Results;
                Parallel.ForEach(bettingEvent.Markets, async market =>
                {
                    var selections = await ValidateResultsAsync(market, results);
                    winnerSelections.AddRange(selections);
                });

                return winnerSelections;
            });
        }

        private async Task<IEnumerable<Selection>> ValidateResultsAsync(Market market, EventResults results)
        {
            return await Task.Run(() =>
            {
                var winnerSelections = new List<Selection>();
                Parallel.ForEach(market.Selections, selection =>
                {
                    if (ValidateFootballSelection(selection, results))
                        winnerSelections.Add(selection);
                });
                return winnerSelections;
            });
        }


        private bool ValidateFootballSelection(Selection selection, EventResults results)
        {
            var winningCondition = selection.WinningCondition;

            if (winningCondition.IsOutright)
            {
                return ValidateOutrightResult(winningCondition, results);
            }
            return ValidateOtherScenarios(winningCondition, results);
        }

        private bool ValidateOtherScenarios(WinningCondition winningCondition, EventResults results)
        {
            if (results.TeamAWin)
            {
                return winningCondition.TeamAWin && results.TeamAScore == winningCondition.TeamAScore &&
                       winningCondition.TeamBScore == results.TeamBScore;
            }
            if (results.TeamBWin)
            {
                return winningCondition.TeamBWin && results.TeamAScore == winningCondition.TeamAScore &&
                       winningCondition.TeamBScore == results.TeamBScore;
            }
            return true;
        }

        private bool ValidateOutrightResult(WinningCondition winningCondition, EventResults results)
        {
            if (results.TeamAWin)
            {
                return winningCondition.TeamAWin;
            }
            if (results.TeamBWin)
            {
                return winningCondition.TeamBWin;
            }
            return true;
        }
    }
}