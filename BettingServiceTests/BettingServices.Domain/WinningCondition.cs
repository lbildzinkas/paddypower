namespace BettingServices.Domain
{
    public class WinningCondition
    {
        public bool IsOutright { get; set; }
        public bool TeamAWin => TeamAScore > TeamBScore;
        public bool TeamBWin => TeamBScore > TeamAScore;
        public bool Draw => TeamAScore == TeamBScore;
        public int TeamAScore { get; set; }
        public int TeamBScore { get; set; }
        public ICustomCondition CustomCondition { get; set; }
    }
}