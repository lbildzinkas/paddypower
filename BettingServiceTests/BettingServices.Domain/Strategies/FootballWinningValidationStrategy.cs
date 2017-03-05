using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BettingServices.Domain.Strategies
{
    public class FootballWinningValidationStrategy : IWinningValidationStrategy
    {
        public IEnumerable<Selection> GetWinningSelections(Event bettingEvent)
        {
            var winnerSelections = new List<Selection>();
            var results = bettingEvent.Results;
            Parallel.ForEach(bettingEvent.Markets, market =>
            {
                var selections = ValidateResults(market, results);
                Object lockMe = new Object();
                lock (lockMe)
                {
                    winnerSelections.AddRange(selections);
                }
            });

            return winnerSelections;
        }

        private IEnumerable<Selection> ValidateResults(Market market, EventResults results)
        {
            var winnerSelections = new List<Selection>();
            Parallel.ForEach(market.Selections, selection =>
            {
                if (ValidateFootballSelection(selection, results))
                {
                    Object lockMe = new Object();
                    lock (lockMe)
                    {
                        winnerSelections.Add(selection);
                    }
                }
            });
            return winnerSelections;
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
            return winningCondition.Draw && results.TeamAScore == winningCondition.TeamAScore &&
                   winningCondition.TeamBScore == results.TeamBScore;
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
            return winningCondition.Draw;
        }
    }
}