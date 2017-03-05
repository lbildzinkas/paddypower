using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization.Formatters;

namespace BettingServices.Domain
{
    public static class EventBuilder
    {
        public static Event CreateEvent(string name, Sport evenSport)
        {
            var bettingEvent = new Event(name, evenSport);
            return bettingEvent;
        }

        public static Event WithMarket(this Event bettingEvent, Market market)
        {
            bettingEvent.Markets.Add(market);
            return bettingEvent;
        }

        public static Event WithBet(this Event bettingEvent, Bet bet)
        {
            bettingEvent.Bets.Add(bet);
            return bettingEvent;
        }

        public static Event WithScoreResults(this Event bettingEvent, int teamAScore, int teamBScore)
        {
            bettingEvent.Results.TeamAScore = teamAScore;
            bettingEvent.Results.TeamBScore = teamBScore;
            return bettingEvent;
        }

        public static Event WithGame(this Event bettingEvent, int setNumber, int gameNumber, bool player1)
        {
            var tennis = bettingEvent.Results.Results as TennisResult;
            if (tennis == null)
            {
                tennis = new TennisResult();
                bettingEvent.Results.Results = tennis;
            }
                

            var set = new Set() { SetNumber = setNumber };
            if (tennis.Sets == null)
                tennis.Sets = new List<Set>();
            tennis.Sets.Add(set);

            var game = new Game() { GameNumber = gameNumber };
            if (set.Games == null)
                set.Games = new List<Game>();
            set.Games.Add(game);
            game.Player1Win = player1;
            return bettingEvent;
        }

        public static Market CreateMarket(string description)
        {
            var bettingEvent = new Market()
            {
                Description = description
            };
            return bettingEvent;
        }

        public static Market WithSelection(this Market market, Selection selection)
        {
            market.Selections.Add(selection);
            return market;
        }

        public static Selection CreateSelection(int odd1, int odd2, bool isOutright, int teamAScore, int teamBScore)
        {
            var selection = new Selection(odd1, odd2, isOutright, teamAScore, teamBScore);
            return selection;
        }

        public static Selection WithTennisWinningConditions(this Selection selection, int gameNumber, bool isGameValidation,
            bool player1Win, int setNumber)
        {
            selection.WinningCondition.CustomCondition = new TennisCondition()
            {
                GameNumber = gameNumber,
                IsGameValidation = isGameValidation,
                Player1Win = player1Win,
                SetNumber = setNumber
            };
            return selection;
        }

        public static Bet CreateBet(decimal betAmmount, Selection selection)
        {
            var bet = new Bet()
            {
                BetAmmount = betAmmount,
                SelectionBet = selection
            };
            return bet;
        }
    }
}