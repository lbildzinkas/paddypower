namespace BettingServices.Domain
{
    public class WinningCondition
    {
        public bool IsOutright { get; set; }
        public bool TeamAWin { get; set; }
        public bool TeamBWin { get; set; }
        public bool Draw { get; set; }
        public int TeamAScore { get; set; }
        public int TeamBScore { get; set; }
        public ICustomCondition CustomCondition { get; set; }
    }
}