using System.Collections.Generic;

namespace BettingService.Tests.Domain
{
    public class CustomResult
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public IList<CustomResult> ChildResults { get; set; }
    }
}