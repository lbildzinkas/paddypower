using System;

namespace BettingServices.Domain
{
    public class Punter
    {
        public Guid Id { get; set; }
        public decimal Balance { get; set; }
    }
}