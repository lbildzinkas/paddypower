using System;
using System.Collections.Generic;

namespace BettingServices.Domain
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Sport EventSport { get; set; }
        public IList<Market> Markets { get; set; }
        public IList<Bet> Bets { get; set; }
        public EventResults Results { get; set; }

        public Event(string description, Sport eventSport)
        {
            Description = description;
            EventSport = eventSport;
            Id = Guid.NewGuid();
            Markets = new List<Market>();
            Bets = new List<Bet>();
            Results = new EventResults();
        }
    }
}
