using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;

namespace BettingService.Tests.Domain
{
    public class Event : IEvent
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
        }
    }

    public interface IEvent
    {
    }
}
