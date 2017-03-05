using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BettingServices.Domain.Strategies
{
    public class TennisWinningValidationStrategy : IWinningValidationStrategy
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
            var tennisResults = results.Results as TennisResult;
            var tennisCondition = winningCondition.CustomCondition as TennisCondition;
            var set = tennisResults.Sets.FirstOrDefault(s => s.SetNumber == tennisCondition.SetNumber);
            if (tennisCondition.IsGameValidation)
            {
                var game = set.Games.FirstOrDefault(g => g.GameNumber == tennisCondition.GameNumber);
                return tennisCondition.Player1Win == game.Player1Win;
            }
            return set.Player1Win == tennisCondition.Player1Win;
        }

        private bool ValidateOutrightResult(WinningCondition winningCondition, EventResults results)
        {
            if (results.TeamAWin)
            {
                return winningCondition.TeamAWin;
            }
            else
            {
                return winningCondition.TeamBWin;
            }
        }
    }
}