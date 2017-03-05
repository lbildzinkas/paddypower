using System.Collections.Generic;

namespace BettingServices.Domain
{
    public class Set
    {
        public Set()
        {
            Games = new List<Game>();
        }
        public bool Player1Win { get; set; }
        public int SetNumber { get; set; }
        public IList<Game> Games { get; set; }
    }
}