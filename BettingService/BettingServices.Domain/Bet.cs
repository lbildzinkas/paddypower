using System;

namespace BettingServices.Domain
{
    public class Bet
    {
        public Punter Punter { get; set; }
        public decimal BetAmmount { get; set; }
        public Guid EventId { get; set; }
        public Selection SelectionBet { get; set; }
    }
}
