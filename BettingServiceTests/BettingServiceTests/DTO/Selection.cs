namespace BettingService.Tests.DTO
{
    public class Selection
    {
        public FractionOdd Odd { get; set; }
        public WinningCondition WinningCondition { get; set; }
    }

    public class WinningCondition
    {
        //different strategy for winning
        public string Team { get; set; }
        public int Set { get; set; }
        public int Game { get; set; }
        public bool IsOutright { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
    }
}