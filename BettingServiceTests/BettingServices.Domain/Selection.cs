using System;

namespace BettingServices.Domain
{
    public class Selection
    {
        public Guid Id { get; set; }
        public FractionOdd Odd { get; set; }
        public WinningCondition WinningCondition { get; set; }
    }
}