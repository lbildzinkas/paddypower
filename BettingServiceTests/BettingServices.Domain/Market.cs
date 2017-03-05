using System;
using System.Collections.Generic;

namespace BettingServices.Domain
{
    public class Market
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public IList<Selection> Selections { get; set; }
    }
}
