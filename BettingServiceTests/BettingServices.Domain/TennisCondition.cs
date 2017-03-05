namespace BettingServices.Domain
{
    public class TennisCondition : ICustomCondition
    {
        public bool IsGameValidation { get; set; }
        public int SetNumber { get; set; }
        public int GameNumber { get; set; }
        public bool Player1Win { get; set; }
    }
}