using System;

namespace BettingService.Tests.Domain
{
    public class Selection
    {
        public Guid Id { get; set; }
        public FractionOdd Odd { get; set; }
        //todo: it could be a good idea to implement IWinning condition and then valuating different winning conditions according with the implementation
        public WinningCondition WinningCondition { get; set; }
    }
}