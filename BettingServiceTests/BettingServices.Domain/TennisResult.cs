using System.Collections.Generic;

namespace BettingServices.Domain
{
    public class TennisResult : ICustomResult
    {
        public IList<Set> Sets { get; set; }
    }
}