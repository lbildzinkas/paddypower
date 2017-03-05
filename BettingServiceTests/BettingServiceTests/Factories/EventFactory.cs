using System;
using System.Collections.Generic;
using BettingServices.Domain;

namespace BettingService.Tests.Factories
{
    public static class EventFactory
    {
        public static Event CreateFootballEvent()
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
                Description = "Outright result in normal time",
                Selections = selections
            };

            var bettingEvent = new Event("Paddy Power Cup Final", Sport.Football);
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

            var eventResults = new EventResults()
            {
                TeamAScore = 2,
                TeamBScore = 0
            };

            bettingEvent.Results = eventResults;

            return bettingEvent;
        }

        public static Event CreateFootballEventScoreMarket()
        {
            var scoreSelections = new List<Selection>()
            {
                new Selection()
                {
                    Id = Guid.NewGuid(),
                    Odd = new FractionOdd(11, 4),
                    WinningCondition = new WinningCondition()
                    {
                        IsOutright = false,
                        TeamAWin = true,
                        TeamAScore = 1,
                        TeamBScore = 0
                    }
                },
                new Selection()
                {
                    Id = Guid.NewGuid(),
                    Odd = new FractionOdd(11, 4),
                    WinningCondition = new WinningCondition()
                    {
                        IsOutright = false,
                        TeamBWin = true,
                        TeamAScore = 0,
                        TeamBScore = 1
                    }
                },
                new Selection()
                {
                    Id = Guid.NewGuid(),
                    Odd = new FractionOdd(11, 4),
                    WinningCondition = new WinningCondition()
                    {
                        IsOutright = false,
                        Draw = true,
                        TeamAScore = 0,
                        TeamBScore = 0
                    }
                },
                new Selection()
                {
                    Id = Guid.NewGuid(),
                    Odd = new FractionOdd(11, 4),
                    WinningCondition = new WinningCondition()
                    {
                        IsOutright = false,
                        TeamAWin = true,
                        TeamAScore = 3,
                        TeamBScore = 0
                    }
                }

            };

            var scoreMarket = new Market()
            {
                Id = Guid.NewGuid(),
                Selections = scoreSelections
            };


            var bettingEvent = new Event("Paddy Power Cup Final", Sport.Football)
            {
                Markets = new List<Market> {scoreMarket}
            };

            var bets = new List<Bet>()
            {
                new Bet()
                {
                    BetAmmount = 4,
                    SelectionBet = scoreSelections[0],
                    EventId = bettingEvent.Id,
                    Punter = new Punter() {Balance = 50,Id = Guid.NewGuid() }
                },
                new Bet()
                {
                    BetAmmount = 4,
                    SelectionBet = scoreSelections[2],
                    EventId = bettingEvent.Id,
                    Punter = new Punter() {Balance = 50,Id = Guid.NewGuid() }
                },
                new Bet()
                {
                    BetAmmount = 2,
                    SelectionBet = scoreSelections[0],
                    EventId = bettingEvent.Id,
                    Punter = new Punter() {Balance = 50,Id = Guid.NewGuid() }
                },
            };

            bettingEvent.Bets = bets;

            var eventResults = new EventResults()
            {
                TeamAScore = 2,
                TeamBScore = 0
            };

            bettingEvent.Results = eventResults;

            return bettingEvent;
        }

        public static Event CreateFootballEventTwoMarkets()
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

            var scoreSelections = new List<Selection>()
            {
                new Selection()
                {
                    Id = Guid.NewGuid(),
                    Odd = new FractionOdd(11, 4),
                    WinningCondition = new WinningCondition()
                    {
                        IsOutright = false,
                        TeamAWin = true,
                        TeamAScore = 1,
                        TeamBScore = 0
                    }
                },
                new Selection()
                {
                    Id = Guid.NewGuid(),
                    Odd = new FractionOdd(11, 4),
                    WinningCondition = new WinningCondition()
                    {
                        IsOutright = false,
                        TeamBWin = true,
                        TeamAScore = 0,
                        TeamBScore = 1
                    }
                },
                new Selection()
                {
                    Id = Guid.NewGuid(),
                    Odd = new FractionOdd(11, 4),
                    WinningCondition = new WinningCondition()
                    {
                        IsOutright = false,
                        Draw = true,
                        TeamAScore = 0,
                        TeamBScore = 0
                    }
                },
                new Selection()
                {
                    Id = Guid.NewGuid(),
                    Odd = new FractionOdd(11, 4),
                    WinningCondition = new WinningCondition()
                    {
                        IsOutright = false,
                        TeamAWin = true,
                        TeamAScore = 3,
                        TeamBScore = 0
                    }
                }

            };

            var outrightMarket = new Market()
            {
                Id = Guid.NewGuid(),
                Selections = selections
            };

            var scoreMarket = new Market()
            {
                Id = Guid.NewGuid(),
                Selections = scoreSelections
            };


            var bettingEvent = new Event("Paddy Power Cup Final", Sport.Football)
            {
                Markets = new List<Market> { outrightMarket, scoreMarket }
            };

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

            var eventResults = new EventResults()
            {
                TeamAScore = 2,
                TeamBScore = 0
            };

            bettingEvent.Results = eventResults;

            return bettingEvent;
        }

        public static Event WithScore(this Event bettingEvent, int teamAScore, int teamBScore)
        {
            bettingEvent.Results.TeamAScore = teamAScore;
            bettingEvent.Results.TeamBScore = teamBScore;
            return bettingEvent;
        }
    }
}