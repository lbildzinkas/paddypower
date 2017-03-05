using System;
using System.Collections.Generic;
using System.Linq;
using BettingServices.Domain;

namespace BettingService.Tests.Factories
{
    public static class EventFactory
    {
        #region FootballEvents

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
                        TeamAScore = 1,
                        TeamBScore = 0
                    }
                },
                new Selection()
                {
                    Id = Guid.NewGuid(),
                    Odd = new FractionOdd(13, 5),
                    WinningCondition = new WinningCondition()
                    {
                        IsOutright = true,
                        TeamAScore = 0,
                        TeamBScore = 1
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
                        TeamBScore = 0,
                        TeamAScore = 0
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
                Markets = new List<Market> { scoreMarket }
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
                        TeamAScore = 1,
                        TeamBScore = 0
                    }
                },
                new Selection()
                {
                    Id = Guid.NewGuid(),
                    Odd = new FractionOdd(13, 5),
                    WinningCondition = new WinningCondition()
                    {
                        IsOutright = true,
                        TeamAScore = 0,
                        TeamBScore = 1
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
                        TeamAScore = 0,
                        TeamBScore = 0
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


        #endregion

        #region Fluent

        public static Event WithScore(this Event bettingEvent, int teamAScore, int teamBScore)
        {
            bettingEvent.Results.TeamAScore = teamAScore;
            bettingEvent.Results.TeamBScore = teamBScore;
            return bettingEvent;
        }

        public static Event WithSet(this Event bettingEvent, int setNumber, bool player1)
        {
            var tennis = bettingEvent.Results.Results as TennisResult;
            var set = tennis.Sets.FirstOrDefault(s => s.SetNumber == setNumber);
            if (set == null)
            {
                set = new Set() { SetNumber = setNumber };
                tennis.Sets.Add(set);
            }
            set.Player1Win = player1;
            return bettingEvent;
        }

        public static Event WithGame(this Event bettingEvent, int setNumber, int gameNumber, bool player1)
        {
            var tennis = bettingEvent.Results.Results as TennisResult;
            if (tennis != null)
            {
                tennis = new TennisResult();
                bettingEvent.Results.Results = tennis;
            }

            var set = new Set() { SetNumber = setNumber };
            if (tennis.Sets == null)
                tennis.Sets = new List<Set>();
            tennis.Sets.Add(set);

            var game = new Game() { GameNumber = gameNumber };
            if(set.Games == null)
                set.Games = new List<Game>();
            set.Games.Add(game);
            game.Player1Win = player1;
            return bettingEvent;
        }

    #endregion

    #region TennisEvents

    public static Event CreateTennisEvent()
    {
        var selections = new List<Selection>()
            {
                new Selection()
                {
                    Id = Guid.NewGuid(),
                    Odd = new FractionOdd(9, 4),
                    WinningCondition = new WinningCondition()
                    {
                        IsOutright = true,
                        TeamAScore = 1,
                        TeamBScore = 0
                    }
                },
                new Selection()
                {
                    Id = Guid.NewGuid(),
                    Odd = new FractionOdd(3, 10),
                    WinningCondition = new WinningCondition()
                    {
                        IsOutright = true,
                        TeamAScore = 0,
                        TeamBScore = 1
                    }
                }
            };

        var outrightMarket = new Market()
        {
            Id = Guid.NewGuid(),
            Description = "Match Betting market",
            Selections = selections
        };

        var bettingEvent = new Event("L Harte v C Ryan tennis match", Sport.Tennis);
        bettingEvent.Markets.Add(outrightMarket);

        var bets = new List<Bet>()
            {
                new Bet()
                {
                    BetAmmount = 5,
                    SelectionBet = selections[0],
                    EventId = bettingEvent.Id,
                    Punter = new Punter() {Balance = 50,Id = Guid.NewGuid() }
                },
                new Bet()
                {
                    BetAmmount = 6,
                    SelectionBet = selections[1],
                    EventId = bettingEvent.Id,
                    Punter = new Punter() {Balance = 50,Id = Guid.NewGuid() }
                },
                new Bet()
                {
                    BetAmmount = 1,
                    SelectionBet = selections[0],
                    EventId = bettingEvent.Id,
                    Punter = new Punter() {Balance = 50,Id = Guid.NewGuid() }
                },
            };

        bettingEvent.Bets = bets;

        var eventResults = new EventResults()
        {
            TeamAScore = 3,
            TeamBScore = 0
        };

        bettingEvent.Results = eventResults;

        return bettingEvent;
    }

    public static Event CreateTennisEventSet2Game1Market()
    {
        var selections = new List<Selection>()
            {
                new Selection()
                {
                    Id = Guid.NewGuid(),
                    Odd = new FractionOdd(4, 7),
                    WinningCondition = new WinningCondition()
                    {
                        IsOutright = false,
                        TeamAScore = 1,
                        TeamBScore = 0,
                        CustomCondition = new TennisCondition()
                        {
                            GameNumber = 1,
                            IsGameValidation = true,
                            Player1Win = true,
                            SetNumber = 2
                        }
                    }
                },
                new Selection()
                {
                    Id = Guid.NewGuid(),
                    Odd = new FractionOdd(5, 4),
                    WinningCondition = new WinningCondition()
                    {
                        IsOutright = false,
                        TeamBScore = 1,
                        TeamAScore = 0,
                        CustomCondition = new TennisCondition()
                        {
                            GameNumber = 1,
                            IsGameValidation = true,
                            Player1Win = false,
                            SetNumber = 2
                        }
                    }
                }
            };

        var outrightMarket = new Market()
        {
            Id = Guid.NewGuid(),
            Description = "To win Set 2 1 st game",
            Selections = selections
        };

        var bettingEvent = new Event("L Harte v C Ryan tennis match", Sport.Tennis);
        bettingEvent.Markets.Add(outrightMarket);

        var bets = new List<Bet>()
            {
                new Bet()
                {
                    BetAmmount = 5,
                    SelectionBet = selections[0],
                    EventId = bettingEvent.Id,
                    Punter = new Punter() {Balance = 50,Id = Guid.NewGuid() }
                },
                new Bet()
                {
                    BetAmmount = 6,
                    SelectionBet = selections[1],
                    EventId = bettingEvent.Id,
                    Punter = new Punter() {Balance = 50,Id = Guid.NewGuid() }
                },
                new Bet()
                {
                    BetAmmount = 1,
                    SelectionBet = selections[0],
                    EventId = bettingEvent.Id,
                    Punter = new Punter() {Balance = 50,Id = Guid.NewGuid() }
                },
            };

        bettingEvent.Bets = bets;

        var eventResults = new EventResults()
        {
            TeamAScore = 3,
            TeamBScore = 0,
            Results = new TennisResult()
        };

        bettingEvent.Results = eventResults;

        return bettingEvent;
    }
    #endregion
}
}