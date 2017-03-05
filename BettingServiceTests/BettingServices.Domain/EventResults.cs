namespace BettingServices.Domain
{
    public class EventResults
    {
        public bool TeamAWin => TeamAScore > TeamBScore;
        public bool TeamBWin => TeamBScore > TeamAScore;
        public bool Draw => TeamAScore == TeamBScore;
        public int TeamAScore { get; set; }
        public int TeamBScore { get; set; }
        public ICustomResult Results { get; set; }
    }
}