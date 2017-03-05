using System;

namespace BettingServices.Domain
{
    public class Selection
    {
        public Guid Id { get; set; }
        public FractionOdd Odd { get; set; }
        public WinningCondition WinningCondition { get; set; }

        public Selection()
        {
            
        }

        public Selection(int odd1, int odd2, bool isOutright, int teamAScore, int teamBScore)
        {
            Id = Guid.NewGuid();
            Odd = new FractionOdd(odd1, odd2);
            WinningCondition = new WinningCondition()
            {
                IsOutright = isOutright,
                TeamAScore = teamAScore,
                TeamBScore = teamBScore
            };
        }
    }
}