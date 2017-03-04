using System;
using System.Collections.Generic;

namespace BettingService.Tests.Domain
{
    public class Market
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public IList<Selection> Selections { get; set; }
    }
}
